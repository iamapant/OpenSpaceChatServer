using Api.Database.Models;
using Microsoft.EntityFrameworkCore;
using ZiggyCreatures.Caching.Fusion;

namespace Api.Database;

public class AppDbContext : DbContext {
    public DbSet<Message> Messages { get; set; }
    public DbSet<Frame> MessageFrames { get; set; }
    public DbSet<FrameOptions> Frames { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<StickerStyle> Stickers { get; set; }
    public DbSet<PrivateMessage> PrivateMessages { get; set; }
    public DbSet<PrivateArchive> PrivateArchives { get; set; }
    public DbSet<PublicMessage> PublicMessages { get; set; }
    public DbSet<PublicArchive> PublicArchives { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<FontFamily> FontFamilies { get; set; }
    public DbSet<FontStyle> FontStyles { get; set; }
    public DbSet<SupportTicket> SupportTickets { get; set; }
    public DbSet<Inbox> Inboxes { get; set; }
    public DbSet<Landmark> Landmarks { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserBlacklist> Blacklists { get; set; }
    public DbSet<UserMessageDecoration> DefaultMessageDecorations { get; set; }
    public DbSet<UserTimeout> Timeouts { get; set; }
    public DbSet<CuratorSettings> CuratorSettings { get; set; }
    public DbSet<AdminSettings> AdminSettings { get; set; }
    public DbSet<OldPassword> OldPasswords { get; set; }
    public DbSet<ChannelSetting> ChannelSettings { get; set; }

    private FusionCache _cache;

    public AppDbContext(DbContextOptions options) : base(options) { SetUpCache(); }

    public AppDbContext() { SetUpCache(); }

    private void SetUpCache() {
        _cache = new FusionCache(new FusionCacheOptions() {
            DefaultEntryOptions = new FusionCacheEntryOptions(TimeSpan.FromMinutes(10))
        });
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured) {
            var config = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .Build();
            var str = config.GetConnectionString("DefaultConnection")
                //Fallback
             ?? "Host=localhost; Database=OpenSpaceChat; Username=postgres; Password=1";
            optionsBuilder.UseNpgsql(str);

            // optionsBuilder.UseNpgsql(
            //     "Host=localhost; Database=OpenSpaceChat; Username=postgres; Password=1");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Message>().UseTptMappingStrategy();

        ModelCreationRepository.ApplyAll(modelBuilder);

        ModelCreationRepository.SeedUser(modelBuilder);
    }
}