using Microsoft.EntityFrameworkCore;
using Regional.Database.Models;
using Regional.Database.Models.Timeout;

namespace Regional.Database;

public class RegionalDbContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Inbox> Inboxes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Landmark> Landmarks { get; set; }
    public DbSet<TimeoutUser> TimeoutUsers { get; set; }
    public DbSet<TimeoutVote> TimeoutVotes { get; set; }
    public DbSet<Decoration> Decorations { get; set; }
    public DbSet<FontFamily> FontFamilies { get; set; }
    public DbSet<FontStyle> FontStyles { get; set; }
    public DbSet<Frame> Frames { get; set; }
    public DbSet<FrameOptions>  FrameOptions { get; set; }
    public DbSet<UserDecoration>  UserDecorations { get; set; }
    public DbSet<MessageDecoration>  MessageDecorations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured) {
            var config = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .Build();
            var str = config.GetConnectionString("DefaultConnection")
                //Fallback
             ?? "RegionalDb";
            optionsBuilder.UseInMemoryDatabase(str);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        ModelCreationRepository.ApplyAll(modelBuilder);
    }
}