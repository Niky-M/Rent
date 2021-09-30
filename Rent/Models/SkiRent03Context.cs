using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Rent.Models
{
    public partial class SkiRent03Context : DbContext
    {
        public SkiRent03Context()
        {
        }

        public SkiRent03Context(DbContextOptions<SkiRent03Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;Database=SkiRent03;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentId).ValueGeneratedNever();

                entity.Property(e => e.EquiomentName).IsRequired();

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipment_Parameter");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.ClientId, "IX_Orders_ClientId");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.StuffId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Orders_Clients");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("Parameter");

                entity.Property(e => e.ParameterId).ValueGeneratedNever();

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Parameter_Brand");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_Parameter_Level");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).ValueGeneratedNever();

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_Service_Equipment");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Service_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
