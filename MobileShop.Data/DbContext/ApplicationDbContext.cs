namespace MobileShop.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MobileShop.Data.Entities;
    public class MobileShopDbContext : IdentityDbContext<User>
    {
        public MobileShopDbContext(DbContextOptions<MobileShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Phone> Phones { get; init; }

        public DbSet<Brand> Brands { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Dealer> Dealers { get; init; }

        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Phone>(entity =>
            {
                entity.HasOne(p => p.Brand)
                    .WithMany(b => b.Phones)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Phones)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Dealer)
                    .WithMany(d => d.Phones)
                    .HasForeignKey(p => p.DealerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            });

            builder
                .Entity<Dealer>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Dealer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

