using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Api.Grpc;
using Api.Providers.Token;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Api.IntraServer.GRpc;

public class RegionalAuthValidation : AuthValidationService.AuthValidationServiceBase {
    private readonly JwtTokenProvider _provider;

    public RegionalAuthValidation(JwtTokenProvider provider) {
        _provider = provider;
    }

    public override async Task<ValidateResult> Validate(ValidateRequest request
      , ServerCallContext context) {
        try {
            var principal = _provider.ValidateToken(request.Token, out var token);

            if (principal == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid token"));

            long expLong = long.MaxValue;
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var roleId = principal.FindFirst(ClaimTypes.Role)?.Value;
            var exp = principal.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;
            var jti = principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            if (!Guid.TryParse(userId, out _))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid user id"));
            if (!Guid.TryParse(roleId, out _))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid role id"));
            if (!Guid.TryParse(jti, out _))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid jti"));
            if (exp != null && !long.TryParse(exp, out expLong))
                throw new RpcException(new Status(StatusCode.InvalidArgument
                  , "Invalid expiration"));


            return new ValidateResult() {
                IsValid = true
              , Message = ""
              , UserId = userId
              , Roles = roleId
              , ExpiresAt = expLong
            };
        } catch (Exception ex) {
            return new ValidateResult() {
                IsValid = false
              , Message = ex.Message
              , UserId = string.Empty
              , ExpiresAt = 0
              , Roles = string.Empty
            };
        }
    }
}