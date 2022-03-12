using ALPHA_DGS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ALPHA_DGS.Data
{
    public class AlphaDbContext : IdentityDbContext
    {

        public DbSet<Invoer> Onions { get; set; }

        public DbSet<Rij> Rijen { get; set; }

        public DbSet<Rij2> Rijen2 { get; set; }

        public DbSet<Rij3> Rijen3 { get; set; }

        public DbSet<Rij4> Rijen4 { get; set; }

        public DbSet<Rij5> Rijen5 { get; set; }

        public DbSet<Rij6> Rijen6 { get; set; }

        public DbSet<Rij7> Rijen7 { get; set; }

        public DbSet<Afdeling> Afdeling { get; set; }

        public DbSet<RijSet> Boxen { get; set; }

        public DbSet<IdentificatieInvoer> IDinvoer { get; set; }

        public DbSet<VakItem> Hallen { get; set; }



        


        public AlphaDbContext(DbContextOptions<AlphaDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ALPHA_DGS.Models.VakItem> VakItem { get; set; }

    }
}
