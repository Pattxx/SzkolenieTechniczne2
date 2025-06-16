using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwiumSzk2.Entities;

namespace PrzykladoweKolokwiumSzk2
{
    public class TripContextDb : DbContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Trip> Trips => Set<Trip>();

        public TripContextDb(IConfiguration configuration)
             : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=trip;trusted_connection=true;",

                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "kolokwium"));
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            // proste seed‑owanie listy krajów
            b.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Polska" },
                new Country { Id = 2, Name = "Hiszpania" },
                new Country { Id = 3, Name = "Włochy" }
            );
        }
    }
}
