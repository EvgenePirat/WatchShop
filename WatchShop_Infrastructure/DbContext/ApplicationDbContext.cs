using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.Entities.Identities;

namespace WatchShop_Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

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
        public DbSet<IndicationKind> IndicationKinds { get; set; }
        public DbSet<IndicationType> IndicationTypes { get; set; }
        public DbSet<MechanismType> MechanismTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrdersStatus { get; set;}
        public DbSet<Strap> Straps { get; set; }
        public DbSet<StrapMaterial> StrapMaterials { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<WatchAdditionalCharacteristics> WatchAdditionalCharacteristics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WatchAdditionalCharacteristics>()
                .HasKey(wac => new { wac.WatchId, wac.AdditionalCharacteristicsId });

            builder.Entity<WatchAdditionalCharacteristics>()
                .HasOne(wac => wac.Watch)
                .WithMany(watch => watch.WatchAdditionalCharacteristics)
                .HasForeignKey(wac => wac.WatchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WatchAdditionalCharacteristics>()
                .HasOne(wac => wac.AdditionalCharacteristics)
                .WithMany(ach => ach.WatchAdditionalCharacteristics)
                .HasForeignKey(wac => wac.AdditionalCharacteristicsId)
                .OnDelete(DeleteBehavior.Restrict);

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

        }
    }
}
