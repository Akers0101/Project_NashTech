using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => e.ToTable("User"));
            modelBuilder.Entity<Assignment>(e => e.ToTable("Assignment"));
            modelBuilder.Entity<Asset>(e => e.ToTable("Asset"));
            modelBuilder.Entity<Category>(e => e.ToTable("Category"));

            //Assignment
            modelBuilder.Entity<Assignment>()
            .HasOne(u => u.AssignedBy)
            .WithMany(u => u.AssignedBy)
            .HasForeignKey(b => b.AssignedByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<Assignment>()
            .HasOne(u => u.AssignedTo)
            .WithMany(u => u.AssignedTo)
            .HasForeignKey(b => b.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<Assignment>()
            .HasOne(u => u.Asset)
            .WithMany(u => u.Assignments)
            .HasForeignKey(b => b.AssetId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            //Asset
            modelBuilder.Entity<Asset>()
            .HasOne(a => a.Category)
            .WithMany(c=>c.Assets)
            .HasForeignKey(a => a.CategoryId);

            //Seeding data
            modelBuilder.Entity<Category>().HasData(SeedingData.SeedingCategories);
            modelBuilder.Entity<Asset>().HasData(SeedingData.SeedingAssets);
            modelBuilder.Entity<User>().HasData(SeedingData.SeedingUsers);
            modelBuilder.Entity<Assignment>().HasData(SeedingData.SeedingAssignment);
        }
    }
}