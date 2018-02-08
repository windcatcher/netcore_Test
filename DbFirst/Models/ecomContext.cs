using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbFirst
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
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=root;Database=ecom");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BbsAddr>(entity =>
            {
                entity.ToTable("bbs_addr");

                entity.HasIndex(e => e.BuyerId)
                    .HasName("buyer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addr)
                    .IsRequired()
                    .HasColumnName("addr")
                    .HasMaxLength(400);

                entity.Property(e => e.BuyerId)
                    .IsRequired()
                    .HasColumnName("buyer_id")
                    .HasMaxLength(40);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.IsDef)
                    .HasColumnName("is_def")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(80);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(60);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.BbsAddr)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bbs_addr_ibfk_1");
            });

            modelBuilder.Entity<BbsBrand>(entity =>
            {
                entity.ToTable("bbs_brand");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(80);

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("img_url")
                    .HasMaxLength(80);

                entity.Property(e => e.IsDisplay)
                    .HasColumnName("is_display")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WebSite)
                    .HasColumnName("web_site")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<BbsBuyer>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("bbs_buyer");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(18);

                entity.Property(e => e.Addr)
                    .HasColumnName("addr")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(11);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(8);

                entity.Property(e => e.IsDel)
                    .HasColumnName("is_del")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(32);

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(11);

                entity.Property(e => e.RealName)
                    .HasColumnName("real_name")
                    .HasMaxLength(8);

                entity.Property(e => e.RegisterTime)
                    .HasColumnName("register_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<BbsCity>(entity =>
            {
                entity.ToTable("bbs_city");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasColumnType("char(6)");
            });

            modelBuilder.Entity<BbsColor>(entity =>
            {
                entity.ToTable("bbs_color");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("img_url")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<BbsDetail>(entity =>
            {
                entity.ToTable("bbs_detail");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_order_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(11);

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductNo)
                    .HasColumnName("product_no")
                    .HasMaxLength(255);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(11);

                entity.Property(e => e.SkuPrice).HasColumnName("sku_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BbsDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_id");
            });

            modelBuilder.Entity<BbsEmployee>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("bbs_employee");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20);

                entity.Property(e => e.Degree)
                    .HasColumnName("degree")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("img_url")
                    .HasMaxLength(41);

                entity.Property(e => e.IsDel)
                    .HasColumnName("is_del")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(18);

                entity.Property(e => e.RealName)
                    .HasColumnName("real_name")
                    .HasMaxLength(8);

                entity.Property(e => e.School)
                    .HasColumnName("school")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<BbsFeature>(entity =>
            {
                entity.ToTable("bbs_feature");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDel)
                    .HasColumnName("is_del")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BbsImg>(entity =>
            {
                entity.ToTable("bbs_img");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDef)
                    .HasColumnName("is_def")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(80);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BbsImg)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("bbs_img_ibfk_1");
            });

            modelBuilder.Entity<BbsOrder>(entity =>
            {
                entity.ToTable("bbs_order");

                entity.HasIndex(e => e.BuyerId)
                    .HasName("buyer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuyerId)
                    .IsRequired()
                    .HasColumnName("buyer_id")
                    .HasMaxLength(18);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliverFee)
                    .HasColumnName("deliver_fee")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Delivery)
                    .HasColumnName("delivery")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsConfirm)
                    .HasColumnName("isConfirm")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsPaiy)
                    .HasColumnName("is_paiy")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(100);

                entity.Property(e => e.Oid)
                    .IsRequired()
                    .HasColumnName("oid")
                    .HasMaxLength(36);

                entity.Property(e => e.PayableFee).HasColumnName("payable_fee");

                entity.Property(e => e.PaymentCash)
                    .HasColumnName("payment_cash")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PaymentWay)
                    .HasColumnName("payment_way")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.BbsOrder)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bbs_order_ibfk_1");
            });

            modelBuilder.Entity<BbsProduct>(entity =>
            {
                entity.ToTable("bbs_product");

                entity.HasIndex(e => e.BrandId)
                    .HasName("brand_id");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckTime)
                    .HasColumnName("check_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckUserId)
                    .HasColumnName("check_user_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Feature)
                    .HasColumnName("feature")
                    .HasMaxLength(255);

                entity.Property(e => e.IsCommend)
                    .HasColumnName("is_commend")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsDel)
                    .HasColumnName("is_del")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsHot)
                    .HasColumnName("is_hot")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsNew)
                    .HasColumnName("is_new")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsShow)
                    .HasColumnName("is_show")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasMaxLength(30);

                entity.Property(e => e.PackageList).HasColumnName("package_list");

                entity.Property(e => e.Sales)
                    .HasColumnName("sales")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("double(11,0)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BbsProduct)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("bbs_product_ibfk_2");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.BbsProduct)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("bbs_product_ibfk_1");
            });

            modelBuilder.Entity<BbsProvince>(entity =>
            {
                entity.ToTable("bbs_province");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<BbsSku>(entity =>
            {
                entity.ToTable("bbs_sku");

                entity.HasIndex(e => e.ColorId)
                    .HasName("color_id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ColorId)
                    .HasColumnName("color_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasMaxLength(255);

                entity.Property(e => e.DeliveFee).HasColumnName("delive_fee");

                entity.Property(e => e.LastStatus)
                    .HasColumnName("last_status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(80);

                entity.Property(e => e.MarketPrice)
                    .HasColumnName("market_price")
                    .HasColumnType("double(20,2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sales)
                    .HasColumnName("sales")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(5);

                entity.Property(e => e.SkuImg)
                    .HasColumnName("sku_img")
                    .HasMaxLength(80);

                entity.Property(e => e.SkuName)
                    .HasColumnName("sku_name")
                    .HasMaxLength(500);

                entity.Property(e => e.SkuPrice)
                    .HasColumnName("sku_price")
                    .HasColumnType("double(20,2)");

                entity.Property(e => e.SkuSort)
                    .HasColumnName("sku_sort")
                    .HasColumnType("int(5)");

                entity.Property(e => e.SkuType)
                    .HasColumnName("sku_type")
                    .HasColumnType("int(1)");

                entity.Property(e => e.SkuUpperLimit)
                    .HasColumnName("sku_upper_limit")
                    .HasColumnType("int(5)");

                entity.Property(e => e.StockInventory)
                    .HasColumnName("stock_inventory")
                    .HasColumnType("int(5)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnName("update_user_id")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.BbsSku)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("bbs_sku_ibfk_2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BbsSku)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bbs_sku_ibfk_1");
            });

            modelBuilder.Entity<BbsTown>(entity =>
            {
                entity.ToTable("bbs_town");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<BbsType>(entity =>
            {
                entity.ToTable("bbs_type");

                entity.HasIndex(e => e.ParentId)
                    .HasName("FKA8168A929B5A332");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDisplay)
                    .HasColumnName("is_display")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(36);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(200);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");
            });
        }
    }
}
