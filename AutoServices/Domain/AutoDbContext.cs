using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain
{
    public partial class AutoDbContext : DbContext
    {
        public AutoDbContext()
        {
        }

        public AutoDbContext(DbContextOptions<AutoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuto> TAuto { get; set; }
        public virtual DbSet<TMarca> TMarca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source = WILSON_PC\\SQLEXPRESS; Initial Catalog = Auto; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuto>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("T_auto");

                entity.Property(e => e.AutoId)
                    .HasColumnName("auto_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutoAnioFabricacion).HasColumnName("auto_anio_fabricacion");

                entity.Property(e => e.AutoColor)
                    .IsRequired()
                    .HasColumnName("auto_color")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AutoFull)
                    .IsRequired()
                    .HasColumnName("auto_full")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AutoMecanico)
                    .IsRequired()
                    .HasColumnName("auto_mecanico")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AutoNroAsientos).HasColumnName("auto_nro_asientos");

                entity.Property(e => e.AutoNroPlaca)
                    .IsRequired()
                    .HasColumnName("auto_nro_placa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaId).HasColumnName("marca_id");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TAuto)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_auto_T_marca");
            });

            modelBuilder.Entity<TMarca>(entity =>
            {
                entity.HasKey(e => e.MarcaId);

                entity.ToTable("T_marca");

                entity.Property(e => e.MarcaId)
                    .HasColumnName("marca_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarcaNombre)
                    .IsRequired()
                    .HasColumnName("marca_nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
