    using Microsoft.EntityFrameworkCore;
    using RoomRadar_Backend.Models;

    namespace RoomRadar_Backend
    {
        public class BackendDbContext : DbContext
        {
            public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<UserProfile> Profiles { get; set; } 
            public DbSet<UserAccount> UserAccounts { get; set; }
            public DbSet<PendingLandLord> PendingLandLords { get; set; }
            public DbSet<BoardingHouse> BoardingHouses { get; set; }
            public DbSet<Rating> Ratings { get; set; }
            public DbSet<Favorite> Favorites { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Prevent cascading deletes on the relationship between Ratings and Users
                modelBuilder.Entity<Rating>()
                    .HasOne(r => r.User)
                    .WithMany(u => u.Ratings)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                // Prevent cascading deletes on the relationship between Ratings and BoardingHouse
                modelBuilder.Entity<Rating>()
                    .HasOne(r => r.BoardingHouse)
                    .WithMany(bh => bh.Ratings)
                    .HasForeignKey(r => r.BoardingHouseId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                modelBuilder.Entity<Favorite>()
                    .HasOne(r => r.User)
                    .WithMany(u => u.Favorites)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                // Prevent cascading deletes on the relationship between Ratings and BoardingHouse
                modelBuilder.Entity<Favorite>()
                    .HasOne(r => r.BoardingHouse)
                    .WithMany(bh => bh.Favorites)
                    .HasForeignKey(r => r.BoardingHouseId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
            }
        }
    }
