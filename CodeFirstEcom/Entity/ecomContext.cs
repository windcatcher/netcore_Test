using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeFirstEcom
{
    public partial class ecomContext : DbContext
    {
        public ecomContext(DbContextOptions<ecomContext> options) : base(options)
        {
        }
        public virtual DbSet<BbsAddr> BbsAddr { get; set; }
        public virtual DbSet<BbsBrand> BbsBrand { get; set; }
        public virtual DbSet<BbsBuyer> BbsBuyer { get; set; }
        public virtual DbSet<BbsCity> BbsCity { get; set; }
        public virtual DbSet<BbsColor> BbsColor { get; set; }
        public virtual DbSet<BbsDetail> BbsDetail { get; set; }
        public virtual DbSet<BbsEmployee> BbsEmployee { get; set; }
        public virtual DbSet<BbsFeature> BbsFeature { get; set; }
        public virtual DbSet<BbsImg> BbsImg { get; set; }
        public virtual DbSet<BbsOrder> BbsOrder { get; set; }
        public virtual DbSet<BbsProduct> BbsProduct { get; set; }
        public virtual DbSet<BbsProvince> BbsProvince { get; set; }
        public virtual DbSet<BbsSku> BbsSku { get; set; }
        public virtual DbSet<BbsTown> BbsTown { get; set; }
        public virtual DbSet<BbsType> BbsType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;User=root;Password=root;Database=ecom1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class  ecomContextDesignFactory : IDesignTimeDbContextFactory<ecomContext>
    {
        public ecomContext CreateDbContext(string[] args)
        {
            // var optionsBuilder =  new DbContextOptionsBuilder<CatalogContext>()
            //   .UseSqlServer("Server=.;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;Integrated Security=true");
            
            var optionsBuilder = new DbContextOptionsBuilder<ecomContext>() .UseMySql("Server=localhost;User=root;Password=root;Database=ecom1");

            return new ecomContext(optionsBuilder.Options);
        }
    }
}
