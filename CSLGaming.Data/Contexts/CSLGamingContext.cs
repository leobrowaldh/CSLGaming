using CSLGaming.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSLGaming.Data
{
    public class CSLGamingContext(DbContextOptions<CSLGamingContext> builder) : DbContext(builder) // <--- Constructor med parameter som allt detta skall struktureras ifrån
    {
        public DbSet<CategoryProduct> Products => Set<CategoryProduct>();
        public DbSet<AgeRestriction> AgeRestrictions => Set<AgeRestriction>(); // Definerar Databasens utseende genom att säga vilken
        public DbSet<Filter> Filters => Set<Filter>();                         // Entitet skall tillhöra vilken propertie i självaste databasen
        public DbSet<Genere> Generes => Set<Genere>();
        public DbSet<GenereProduct> GenereProducts => Set<GenereProduct>();
        public DbSet<Category> OSs => Set<Category>();
        public DbSet<OSProduct> OsProducts => Set<OSProduct>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Composite keys skapas under (1a alternativet)

            builder.Entity<GenereProduct>() // <-- Skriv in vilken mergetable vi skall gå utifrån
                .HasKey(GP => new { GP.GenereId, GP.ProductId }); // <-- Utge vilka nycklar tillsammans skall skapa en PrimaryKey
            builder.Entity<OSProduct>()
                .HasKey(OP => new { OP.OSId, OP.ProductId });


            // Composite keys (2a alternativet)

            builder.Entity<Genere>()           // <-- Välja singular entitet
                .HasMany(G => G.Products)      // <-- Vilken propertie är many to many
                .WithMany(P => P.Generes)      // <-- Sedan gör du samma sak i motsvarande klass, som den förstnämnda är kopplad till
                .UsingEntity<GenereProduct>(); // <-- Klargör vilken merge table detta tillhör

                                               // (Fråga!) <-- Tror inte vi "behöver" göra på båda sätten, fråga Jonas då han använda sig av båda i sitt projekt
            builder.Entity<Category>()
                .HasMany(O => O.Products)
                .WithMany(P => P.OSs)
            .UsingEntity<OSProduct>();

            //Configuring the precision and scale of the Price property
            builder.Entity<CategoryProduct>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

        }
    }

    
}
