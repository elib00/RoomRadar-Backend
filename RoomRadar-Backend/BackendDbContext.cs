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
            public DbSet<LandLordCredentials> LandLordCredentials { get; set; }
        }
    }
