using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Api.DTO;
using Api.Grpc;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using ZiggyCreatures.Caching.Fusion;

namespace Regional.Services;

public class
    DelegateJwtAuthorizationMiddleware : AuthorizationHandler<RemoteJwtRequirement> {
    private readonly AuthValidationService.AuthValidationServiceClient _authClient;
    private readonly FusionCache _cache;

    public DelegateJwtAuthorizationMiddleware(AuthValidationService.AuthValidationServiceClient authClient, FusionCache cache) {
        _authClient = authClient;
        _cache = cache;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context
      , RemoteJwtRequirement requirement) {
        if (context.Resource is not DefaultHttpContext httpContext) return;

        var token = httpContext.Request.Headers["Authorization"]
                               .FirstOrDefault()
                               ?.Split(' ')
                               .Last();
        if (token is null) return;
        
        //Cache get
        var cache = await _cache.TryGetAsync<ClaimsPrincipal>($"authToken:{token}");
        if (cache.HasValue) {
            httpContext.User = cache.Value;
            context.Succeed(requirement);
            return;
        }

        //Build header - get api key
        var conf = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddUserSecrets<Program>().Build();
        var headers = new Metadata() {
            { "x-api-key", conf.GetSection("MainServerConnection:Secret").Value ?? "" },
            { "x-region-id", conf.GetSection("Region:Id").Value ?? "" }
        };
        var reply = await _authClient.ValidateAsync(new ValidateRequest { Token = token }, headers);
        if (!Guid.TryParse(reply.UserId, out var userId)) return;
        
        var exp = new DateTimeOffset(new DateTime(reply.ExpiresAt));
        var claims = new List<Claim>();
        foreach (var claim in reply.Claims) {
            var dto = JsonConvert.DeserializeObject<ClaimDto>(claim);
            if (dto == null) continue;
            claims.Add(new Claim(dto.Type, dto.Type));
        }
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, reply.UserId));
        claims.Add(new Claim(ClaimTypes.Role,  reply.Role));
        claims.Add(new Claim(JwtRegisteredClaimNames.Exp, exp.ToString("o")));
        
        var identity = new ClaimsIdentity (claims);
        httpContext.User = new ClaimsPrincipal(identity);
        
        //Cache set
        await _cache.SetAsync($"jwt:{token}", httpContext.User);
        
        context.Succeed(requirement);
    }
}

public class Test : AuthValidationService.AuthValidationServiceClient {
    public override AsyncUnaryCall<ValidateResult> ValidateAsync(ValidateRequest request
      , Metadata headers = null
      , DateTime? deadline = null
      , CancellationToken cancellationToken = default(CancellationToken)) {
        return base.ValidateAsync(request, headers, deadline, cancellationToken);
    }
}

public class RemoteJwtRequirement : IAuthorizationRequirement { }