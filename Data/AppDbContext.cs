using Microsoft.EntityFrameworkCore;
using PetPackApi.Models;

namespace PetPackApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Pack)
                .WithOne(p => p.Owner)
                .HasForeignKey<Pack>(p => p.OwnerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}