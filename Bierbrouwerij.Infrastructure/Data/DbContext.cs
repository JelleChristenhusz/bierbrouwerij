using Bierbrouwerij.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bierbrouwerij.Infrastructure.Data
{
    public class BierbrouwerijDbContext : DbContext
    {
        public BierbrouwerijDbContext(DbContextOptions<BierbrouwerijDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bier> Bieren { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bier>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Naam).IsRequired();
                entity.Property(b => b.Beschrijving).IsRequired();
                entity.Property(b => b.Alcoholpercentage).IsRequired();
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Naam).IsRequired();
                entity.Property(i => i.Type).IsRequired();
                entity.Property(i => i.Hoeveelheid).IsRequired();

                entity.HasOne(i => i.Bier)
                    .WithMany(b => b.Ingredienten)
                    .HasForeignKey(i => i.BierId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Bier>().HasData(
                new Bier { Id = 1, Naam = "Tripel Karmeliet", Beschrijving = "Een fruitig Belgisch tripelbier", Alcoholpercentage = 8.4 },
                new Bier { Id = 2, Naam = "Westmalle Dubbel", Beschrijving = "Een donker abdijbier met karamelsmaken", Alcoholpercentage = 7.0 },
                new Bier { Id = 3, Naam = "Heineken", Beschrijving = "Een fris en licht lagerbier", Alcoholpercentage = 5.0 }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                // Tripel Karmeliet
                new Ingredient { Id = 1, Naam = "Pilsnermout", Type = "Mout", Hoeveelheid = 4.5, BierId = 1 },
                new Ingredient { Id = 2, Naam = "Saaz", Type = "Hop", Hoeveelheid = 30, BierId = 1 },
                new Ingredient { Id = 3, Naam = "Tarwe", Type = "Graan", Hoeveelheid = 1.5, BierId = 1 },
                new Ingredient { Id = 4, Naam = "Belgische gist", Type = "Gist", Hoeveelheid = 0.5, BierId = 1 },

                // Westmalle Dubbel
                new Ingredient { Id = 5, Naam = "Karamelizmout", Type = "Mout", Hoeveelheid = 5.0, BierId = 2 },
                new Ingredient { Id = 6, Naam = "Hallertau", Type = "Hop", Hoeveelheid = 25, BierId = 2 },
                new Ingredient { Id = 7, Naam = "Abdijgist", Type = "Gist", Hoeveelheid = 0.5, BierId = 2 },

                // Heineken
                new Ingredient { Id = 8, Naam = "Pale Ale Mout", Type = "Mout", Hoeveelheid = 3.5, BierId = 3 },
                new Ingredient { Id = 9, Naam = "Cascade", Type = "Hop", Hoeveelheid = 20, BierId = 3 },
                new Ingredient { Id = 10, Naam = "Lagergist", Type = "Gist", Hoeveelheid = 0.5, BierId = 3 }
            );
        }
    }
}