using ALPHA_DGS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ALPHA_DGS.Data
{
    public class AlphaDbContext : IdentityDbContext
    {

        
        public DbSet<IdentificatieInvoer> IDinvoer { get; set; }

        public DbSet<Magazijn> Magazijn { get; set; }

        public DbSet<MagazijnPartij> MagazijnPartij { get; set; }

        public DbSet<Partijserie> Partijserie { get; set; }

        public DbSet<Stadium> Stadium { get; set; }






        public AlphaDbContext(DbContextOptions<AlphaDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        

    }
}
