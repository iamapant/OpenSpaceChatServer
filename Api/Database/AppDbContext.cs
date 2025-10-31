using Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class AppDbContext : DbContext {
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageFrame> MessageFrames { get; set; }
    public DbSet<MessageFrameOptions> Frames { get; set; }
    public DbSet<MessageReaction> Reactions { get; set; }
    public DbSet<MessageStickerStyle> Stickers { get; set; }
    public DbSet<PrivateMessage> PrivateMessages { get; set; }
    public DbSet<PrivateArchive>  PrivateArchives { get; set; }
    public DbSet<PublicMessage> PublicMessages { get; set; }
    public DbSet<PublicArchive>  PublicArchives { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<FontFamily> FontFamilies { get; set; }
    public DbSet<FontStyle> FontStyles { get; set; }
    public DbSet<SupportTicket>  SupportTickets { get; set; }
    public DbSet<Inbox> Inboxes { get; set; }
    public DbSet<Landmark> Landmarks { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserBlacklist> Blacklists { get; set; }
    public DbSet<UserMessageDecoration> DefaultMessageDecorations { get; set; }
    public DbSet<UserTimeout> Timeouts { get; set; }
    public DbSet<CuratorSettings> CuratorSettings { get; set; }
    public DbSet<OldPassword> OldPasswords { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured) {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(
                config.GetConnectionString("DefaultConnection"));

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