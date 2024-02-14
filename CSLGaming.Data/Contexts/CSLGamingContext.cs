

using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CSLGaming.Data
{
    public class CSLGamingContext(DbContextOptions<CSLGamingContext> builder) : DbContext(builder) 
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Filter> Filters => Set<Filter>();                        
        public DbSet<Genere> Generes => Set<Genere>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<AgeRestriction> AgeRestrictions => Set<AgeRestriction>();
        public DbSet<GenereProduct> GenereProducts => Set<GenereProduct>();
        public DbSet<CategoryProduct> CategoryProducts => Set<CategoryProduct>();
        public DbSet<CategoryFilter> CategoryFilters => Set<CategoryFilter>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Composite Keys

            builder.Entity<GenereProduct>() 
                .HasKey(GP => new { GP.GenereId, GP.ProductId }); 
            builder.Entity<CategoryProduct>()
                .HasKey(OP => new { OP.CategoryId, OP.ProductId });
            builder.Entity<CategoryFilter>()
                .HasKey(CF => new { CF.CategoryId, CF.FilterId });
            #endregion

            #region many to many relationships

            builder.Entity<Genere>()          
                .HasMany(g => g.Products)      
                .WithMany(p => p.Generes)      
                .UsingEntity<GenereProduct>();

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .UsingEntity<CategoryProduct>();

            builder.Entity<Category>()
                .HasMany(c => c.Filters)
                .WithMany(f => f.Categories)
                .UsingEntity<CategoryFilter>();

            #endregion

            #region one to many relationships

            builder.Entity<Product>()
               .HasOne(p => p.AgeRestriction)
               .WithMany(a => a.Products)
               .HasForeignKey(p => p.AgeRestrictionId);

            #endregion

            #region property specifications

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            #endregion
        }
    }

    
}
