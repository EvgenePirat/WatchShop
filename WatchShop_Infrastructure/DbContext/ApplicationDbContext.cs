using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.Enums;

namespace WatchShop_Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Image> Images { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles {  get; set; }
        public DbSet<Brend> Brends { get; set; }
        public DbSet<AdditionalCharacteristics> AdditionalCharacteristics { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ClockFace> ClockFace { get; set; }
        public DbSet<ClockFaceColor> ClockFaceColor { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<FrameColor> FrameColors { get; set; }
        public DbSet<FrameMaterial> FrameMaterials { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<IndicationKind> IndicationKinds { get; set; }
        public DbSet<IndicationType> IndicationTypes { get; set; }
        public DbSet<MechanismType> MechanismTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrdersStatus { get; set;}
        public DbSet<Strap> Straps { get; set; }
        public DbSet<StrapMaterial> StrapMaterials { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<WatchAdditionalCharacteristic> WatchAdditionalCharacteristics { get; set; }
        public DbSet<WatchComment> WatchComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Watch>()
                .HasMany(w => w.Comments)
                .WithOne(c => c.Watch)
                .HasForeignKey(c => c.WatchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(w => w.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasMany(o => o.Carts)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Payment>()
                .HasOne(o => o.ApplicationUser)
                .WithMany(u => u.Payments)
                .HasForeignKey(o => o.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Shipment>()
                .HasOne(o => o.ApplicationUser)
                .WithMany(u => u.Shipments)
                .HasForeignKey(o => o.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Watch>()
                .HasMany(w => w.Images)
                .WithOne(i => i.Watch)
                .HasForeignKey(i => i.WatchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WatchAdditionalCharacteristic>()
                .HasKey(wac => new { wac.WatchId, wac.AdditionalCharacteristicsId });

            builder.Entity<WatchAdditionalCharacteristic>()
                .HasOne(wac => wac.Watch)
                .WithMany(watch => watch.WatchAdditionalCharacteristics)
                .HasForeignKey(wac => wac.WatchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WatchAdditionalCharacteristic>()
                .HasOne(wac => wac.AdditionalCharacteristics)
                .WithMany(ach => ach.WatchAdditionalCharacteristics)
                .HasForeignKey(wac => wac.AdditionalCharacteristicsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Cart>()
                .HasKey(cart => new { cart.OrderId, cart.WatchId });

            builder.Entity<Cart>()
                .HasOne(cart => cart.Order)
                .WithMany(order => order.Carts)
                .HasForeignKey(cart => cart.OrderId);

            builder.Entity<Cart>()
                .HasOne(cart => cart.Watch)
                .WithMany(watch => watch.Carts)
                .HasForeignKey(cart => cart.WatchId);

            builder.Entity<Cart>()
                .Property(cart => cart.Count)
                .IsRequired();

            builder.Entity<Country>().HasData(Enum.GetValues(typeof(CountryEnum))
                .Cast<CountryEnum>()
                .Select((value, index) => new Country
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<AdditionalCharacteristics>().HasData(Enum.GetValues(typeof(AdditionalCharacteristicsEnum))
                .Cast<AdditionalCharacteristicsEnum>()
                .Select((value, index) => new AdditionalCharacteristics
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<IndicationKind>().HasData(Enum.GetValues(typeof(IndicationKindEnum))
                .Cast<IndicationKindEnum>()
                .Select((value, index) => new IndicationKind
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<IndicationType>().HasData(Enum.GetValues(typeof(IndicationTypeEnum))
                .Cast<IndicationTypeEnum>()
                .Select((value, index) => new IndicationType
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<ClockFaceColor>().HasData(Enum.GetValues(typeof(ClockFaceColorEnum))
                .Cast<ClockFaceColorEnum>()
                .Select((value, index) => new ClockFaceColor
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<FrameColor>().HasData(Enum.GetValues(typeof(FrameColorEnum))
                .Cast<FrameColorEnum>()
                .Select((value, index) => new FrameColor
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<FrameMaterial>().HasData(Enum.GetValues(typeof(FrameMaterialEnum))
                .Cast<FrameMaterialEnum>()
                .Select((value, index) => new FrameMaterial
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<GlassType>().HasData(Enum.GetValues(typeof(GlassTypeEnum))
                .Cast<GlassTypeEnum>()
                .Select((value, index) => new GlassType
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<MechanismType>().HasData(Enum.GetValues(typeof(MechanismTypeEnum))
                .Cast<MechanismTypeEnum>()
                .Select((value, index) => new MechanismType
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<OrderStatus>().HasData(Enum.GetValues(typeof(OrderStatusEnum))
                .Cast<OrderStatusEnum>()
                .Select((value, index) => new OrderStatus
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<StrapMaterial>().HasData(Enum.GetValues(typeof(StrapMaterialEnum))
                .Cast<StrapMaterialEnum>()
                .Select((value, index) => new StrapMaterial
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));

            builder.Entity<Style>().HasData(Enum.GetValues(typeof(StyleEnum))
                .Cast<StyleEnum>()
                .Select((value, index) => new Style
                {
                    Id = (byte)(index + 1),
                    Name = value
                }));
        }
    }
}
