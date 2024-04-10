using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiGP.Models;

public partial class GuenapPeruContext : DbContext
{
    public GuenapPeruContext()
    {
    }

    public GuenapPeruContext(DbContextOptions<GuenapPeruContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Active> Actives { get; set; }

    public virtual DbSet<AddressCampus> AddressCampuses { get; set; }

    public virtual DbSet<AddressForDelivery> AddressForDeliveries { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<DeliveryMode> DeliveryModes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Shopcart> Shopcarts { get; set; }

    public virtual DbSet<SpViewBrand> SpViewBrands { get; set; }

    public virtual DbSet<SpViewProduct> SpViewProducts { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<TypeDocument> TypeDocuments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9N4UR2R;Initial Catalog=GuenapPeru;Persist Security Info=True;User ID=sa;Password=serv2023;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Active>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__active__3213E83FD0E4488E");

            entity.ToTable("active");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AddressCampus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__addressC__3213E83FA75BD37D");

            entity.ToTable("addressCampus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressDir)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("addressDir");
            entity.Property(e => e.Departamento).HasColumnName("departamento");
            entity.Property(e => e.Distrito).HasColumnName("distrito");
            entity.Property(e => e.Provincia).HasColumnName("provincia");
        });

        modelBuilder.Entity<AddressForDelivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__addressF__3213E83F72E94799");

            entity.ToTable("addressForDelivery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressDir)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("addressDir");
            entity.Property(e => e.Departamento).HasColumnName("departamento");
            entity.Property(e => e.Detalle)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Distrito).HasColumnName("distrito");
            entity.Property(e => e.Provincia).HasColumnName("provincia");
            entity.Property(e => e.Referencia)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brands__3213E83F41705F67");

            entity.ToTable("brands");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IsActiveNavigation).WithMany(p => p.Brands)
                .HasForeignKey(d => d.IsActive)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_brands_active");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F96C8D35F");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IsActiveNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IsActive)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categories_active");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.ToTable("coupons");

            entity.HasIndex(e => e.Code, "UQ__coupons__357D4CF9268A2975").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.EndingDate)
                .HasColumnType("datetime")
                .HasColumnName("ending_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ProductsId).HasColumnName("products_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.IsActiveNavigation).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.IsActive)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_coupons_active");

            entity.HasOne(d => d.Products).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_coupons_products");
        });

        modelBuilder.Entity<DeliveryMode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__delivery__3213E83F8AEA596C");

            entity.ToTable("delivery_mode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("price");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departam__3213E83F51EF6D2A");

            entity.ToTable("departamentos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__distrito__3213E83F578200EA");

            entity.ToTable("distritos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_distritos_provincias");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__images__3213E83F9706AEA2");

            entity.ToTable("images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageOrder).HasColumnName("image_order");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_images_products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83FDF0C38AA");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressE).HasColumnName("addressE");
            entity.Property(e => e.AmountDelivery)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount_delivery");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.DeliveryTy).HasColumnName("delivery_ty");
            entity.Property(e => e.Gravada)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gravada");
            entity.Property(e => e.Igv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("igv");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e => e.StatusOrder).HasColumnName("statusOrder");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_users");

            entity.HasOne(d => d.DeliveryTyNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryTy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_delivery");

            entity.HasOne(d => d.PaymentNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Payment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_payment");

            entity.HasOne(d => d.StatusOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_status");
        });

        modelBuilder.Entity<OrdersDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders_d__3213E83F33516A1F");

            entity.ToTable("orders_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CouponId).HasColumnName("coupon_id");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Gravada)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gravada");
            entity.Property(e => e.Igv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("igv");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.PriceUnit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_unit");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShopcartId).HasColumnName("shopcart_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ordetail_orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrdersDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ordetail_product");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___3213E83F437B6CDB");

            entity.ToTable("payment_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83F6AEF6603");

            entity.ToTable("permissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83FE39C006A");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandsId).HasColumnName("brands_id");
            entity.Property(e => e.CategoriesId).HasColumnName("categories_id");
            entity.Property(e => e.CodeProduct)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("code_product");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Stocks).HasColumnName("stocks");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__provinci__3213E83F50CBCC2F");

            entity.ToTable("provincias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_provincias_departamentos");
        });

        modelBuilder.Entity<Shopcart>(entity =>
        {
            entity.ToTable("shopcart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coupon).HasColumnName("coupon");
            entity.Property(e => e.DateShop)
                .HasColumnType("datetime")
                .HasColumnName("dateShop");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ProductsId).HasColumnName("products_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CouponNavigation).WithMany(p => p.Shopcarts)
                .HasForeignKey(d => d.Coupon)
                .HasConstraintName("fk_shopcart_coupons");

            entity.HasOne(d => d.Products).WithMany(p => p.Shopcarts)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_shopcart_products");

            entity.HasOne(d => d.User).WithMany(p => p.Shopcarts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_shopcart_users");
        });

        modelBuilder.Entity<SpViewBrand>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sp_view_brands");

            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SpViewProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sp_view_products");

            entity.Property(e => e.BrandsId).HasColumnName("brands_id");
            entity.Property(e => e.CategoriesId).HasColumnName("categories_id");
            entity.Property(e => e.CodeProduct)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("code_product");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Stocks).HasColumnName("stocks");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statur_o__3213E83F32190830");

            entity.ToTable("status_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TypeDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_doc__3213E83F0A8F1EF0");

            entity.ToTable("type_document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F0D3CD3F4");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "unique_email").IsUnique();

            entity.HasIndex(e => e.Username, "unique_user").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Departamento).HasColumnName("departamento");
            entity.Property(e => e.Direccion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Distrito).HasColumnName("distrito");
            entity.Property(e => e.Email)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.NumberDocument)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("number_document");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("passwordUser");
            entity.Property(e => e.PermissionsId).HasColumnName("permissions_id");
            entity.Property(e => e.Provincia).HasColumnName("provincia");
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.TypeDocumentu).HasColumnName("type_documentu");
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Departamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_departamento");

            entity.HasOne(d => d.DistritoNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Distrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_distrito");

            entity.HasOne(d => d.IsActiveNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IsActive)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_active");

            entity.HasOne(d => d.Permissions).WithMany(p => p.Users)
                .HasForeignKey(d => d.PermissionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_permissions");

            entity.HasOne(d => d.ProvinciaNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Provincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_provincia");

            entity.HasOne(d => d.TypeDocumentuNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeDocumentu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_type_document");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
