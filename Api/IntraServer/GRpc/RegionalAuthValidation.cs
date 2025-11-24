using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Api.DTO;
using Api.Grpc;
using Api.Providers;
using Api.Providers.Token;
using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Api.IntraServer.GRpc;

public class RegionalAuthValidation : AuthValidationService.AuthValidationServiceBase {
    private readonly JwtTokenProvider _provider;
    private readonly RegionApiKeyProvider _regionApiKey;

    public RegionalAuthValidation(JwtTokenProvider provider, RegionApiKeyProvider regionApiKey) {
        _provider = provider;
        _regionApiKey = regionApiKey;
    }
    
    public override async Task<ValidateResult> Validate(ValidateRequest request
      , ServerCallContext context) {
        try {
            var metadata = context.RequestHeaders;
            var id = metadata.FirstOrDefault(m => m.Key.Equals("x-region-id", StringComparison.OrdinalIgnoreCase))?.Value ?? throw new RpcException(new Status(StatusCode.PermissionDenied, "Invalid region key"));
            var apiKey = metadata.FirstOrDefault(m => m.Key.Equals("x-api-key", StringComparison.OrdinalIgnoreCase))?.Value?? throw new RpcException(new Status(StatusCode.PermissionDenied, "Invalid region key"));
            if (await _regionApiKey.ValidateKey(id, apiKey)) throw new RpcException(new Status(StatusCode.PermissionDenied, "Invalid region key"));
            
            var principal = _provider.ValidateToken(request.Token, out var token);

            if (principal == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid token"));

            DateTimeOffset expDate = DateTimeOffset.MinValue;
            var userId = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            var role = principal.FindFirst(ClaimTypes.Role)?.Value;
            var exp = principal.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;
            var jti = principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            if (!Guid.TryParse(userId, out _))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid user id"));
            if (!Guid.TryParse(jti, out _))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid jti"));
            if (exp != null && !DateTimeOffset.TryParse(exp, out expDate))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid expiration"));

            var claims = principal.Claims.Where(e => 
                                      e.Type != JwtRegisteredClaimNames.Sub
                                   && e.Type != ClaimTypes.Role
                                   && e.Type != JwtRegisteredClaimNames.Exp)
                                  .Select(e => JsonConvert.SerializeObject(new ClaimDto(e.Type, e.Value)));

            var res = new ValidateResult() {
                UserId = userId
              , Role = role
              , ExpiresAt = expDate.Ticks
            };
            res.Claims.AddRange(claims);
            return res;
        } catch (Exception ex) {
            return new ValidateResult() {
                UserId = string.Empty
              , ExpiresAt = 0
              , Role = string.Empty
              , Claims = { ex.Message }
            };
        }
    }
}