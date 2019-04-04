using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BacNetTool.Models
{
    public partial class BACNet_dbContext : DbContext
    {
        public BACNet_dbContext()
        {
        }

        public BACNet_dbContext(DbContextOptions<BACNet_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnalogInput> AnalogInput { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.BACNetConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalogInput>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Covincrement)
                    .HasColumnName("COVIncrement")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Deadband)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaultHighLimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaultLowLimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HighLimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterfaceValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LowLimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MinPresValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectName).IsUnicode(false);

                entity.Property(e => e.PresentValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resolution)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AckedTransistions)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ApdusegmentTimeout).HasColumnName("APDUSegmentTimeout");

                entity.Property(e => e.Apdutimeout).HasColumnName("APDUTimeout");

                entity.Property(e => e.ApplicationSoftwareRevision)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeployedProfileLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirmwareRevision)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalDate).HasColumnType("datetime");

                entity.Property(e => e.LocalTime).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaxAdpulengthAccepted).HasColumnName("MaxADPULengthAccepted");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfApduretries).HasColumnName("NumberOfAPDURetries");

                entity.Property(e => e.ObjectName).IsUnicode(false);

                entity.Property(e => e.ProfileLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Utcoffset).HasColumnName("UTCOffset");

                entity.Property(e => e.VendorIdentifier)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName).IsUnicode(false);

                entity.HasOne(d => d.ObjectTypeNavigation)
                    .WithMany(p => p.InverseObjectTypeNavigation)
                    .HasForeignKey(d => d.ObjectType)
                    .HasConstraintName("FK_ParentDevice");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Covincrement)
                    .HasColumnName("COVIncrement")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Deadband)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HighLimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LowLimit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxPresValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MinPresValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectName).IsUnicode(false);

                entity.Property(e => e.PresentValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelinquishDefault)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resolution)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
