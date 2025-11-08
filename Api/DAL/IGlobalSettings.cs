using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Api.Database;
using Api.Database.Models;
using Api.Providers.Email;
using Api.Providers.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Api.DAL;

public interface IGlobalSettings {
    AdminSettings Admin { get; }
    CuratorSettings Curator { get; }
    EmailSettings Email { get; }
    JwtSettings Jwt { get; }
    
    Task ReloadAllAsync();
    Task ReloadAdminAsync();
    Task ReloadCuratorAsync();
    Task ReloadEmailAsync();
    Task ReloadJwtAsync();
}

public class GlobalSettings : IGlobalSettings {
    private AppDbContext _ctx;
    private JwtSecurityTokenHandler _jwtHandler;
    private TokenValidationParameters _jwtTvp;

    public GlobalSettings(AppDbContext ctx, JwtSecurityTokenHandler jwtHandler, TokenValidationParameters jwtTvp) {
        _ctx = ctx;
        _jwtHandler = jwtHandler;
        _jwtTvp = jwtTvp;
        _ = ReloadAllAsync();
    }

    public AdminSettings Admin {
        get {
            TimeoutReload();
            return _admin;
        }
    }
    
    private AdminSettings _admin;

    public CuratorSettings Curator {
        get {
            TimeoutReload();
            return _curator;
        }
    }
    
    public static DateTime LastRefresh { get; private set; }
    public async Task ReloadAllAsync() {
        await ReloadCuratorAsync();
        await ReloadAdminAsync();
        await ReloadEmailAsync();
        await ReloadJwtAsync();
        
        LastRefresh = DateTime.UtcNow;
    }

    public EmailSettings Email { get; private set; }
    public JwtSettings Jwt { get; private set; }

    private void TimeoutReload() {
        if (LastRefresh.AddHours(_settingsRefreshIntervalInHour) > DateTime.UtcNow) return;

        _ = ReloadAllAsync();
    }

    private CuratorSettings _curator;

    private float _settingsRefreshIntervalInHour { get; set; } = 1;


    public async Task ReloadAdminAsync() {
        _admin = await _ctx.AdminSettings.FirstOrDefaultAsync() ?? throw new Exception("Admin settings not found.");

        _settingsRefreshIntervalInHour = _admin.SettingsRefreshIntervalInHour;
    }

    public async Task ReloadCuratorAsync() {
        _curator = await _ctx.CuratorSettings.FirstOrDefaultAsync() ?? throw new Exception("Curator settings not found.");
    }

    public async Task ReloadEmailAsync() {
        var config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();
        var email = config.GetSection("EmailSettings").Get<EmailSettings>();
        if (email == null) throw new Exception("Email settings not found.");
        Email = email;
    }

    public async Task ReloadJwtAsync() {
        var config = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .AddJsonFile("appsettings.json")
            .Build();
        var jwt = config.GetSection("JwtSettings").Get<JwtSettings>();
        if (jwt == null) throw new Exception("Cannot bind Jwt settings.");
        
        
        Jwt = jwt;
        Jwt.Handler = _jwtHandler;
        Jwt.TokenValidationParameters = _jwtTvp;
    }
}