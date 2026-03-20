using Microsoft.EntityFrameworkCore;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // No indexar una propiedad calculada (FullName).
            // Indexar columnas persistentes: FirstName + LastName.
            modelBuilder.Entity<Owner>()
                .HasIndex(o => new { o.FirstName, o.LastName })
                .IsUnique();
        }
    }
}
