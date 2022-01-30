using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Vehicle_System_API.Models
{
    public partial class VehicleTrackingContext : DbContext
    {
        public VehicleTrackingContext()
        {
        }

        public VehicleTrackingContext(DbContextOptions<VehicleTrackingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<TrackingDetail> TrackingDetails { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=VehicleTracking;User Id=sa;Password=Ahm-2110;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.CompanyLocation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Company_Location");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Company_Name");
            });

            modelBuilder.Entity<TrackingDetail>(entity =>
            {
                entity.HasKey(e => e.TrackingId)
                    .HasName("PK__Tracking__BBD3B0EBC638C786");

                entity.ToTable("Tracking_Details");

                entity.Property(e => e.TrackingId).HasColumnName("Tracking_ID");

                entity.Property(e => e.TrackingDate)
                    .HasColumnType("date")
                    .HasColumnName("Tracking_Date");

                entity.Property(e => e.TrackingDesc)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Tracking_DESC");

                entity.Property(e => e.TrackingLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Tracking_Location");

                entity.Property(e => e.VId).HasColumnName("V_ID");

                entity.HasOne(d => d.VIdNavigation)
                    .WithMany(p => p.TrackingDetails)
                    .HasForeignKey(d => d.VId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Tracking_Vehicle");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_ID");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.ModalYear).HasColumnName("Modal_Year");

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Vehicle_Name");

                entity.Property(e => e.VehicleTypeId).HasColumnName("Vehicle_Type_ID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_to_Company");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_to_VehicleTypes");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("Vehicle_Types");

                entity.Property(e => e.VehicleTypeId).HasColumnName("Vehicle_Type_ID");

                entity.Property(e => e.VehicleTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Vehicle_Type_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
