using Microsoft.EntityFrameworkCore;

namespace USN_Persistence
{
    public partial class MeasurementSitesContext : DbContext
    {
        public MeasurementSitesContext()
        {
        }

        public MeasurementSitesContext(DbContextOptions<MeasurementSitesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MeasuredValue> MeasuredValues { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sensor> Sensors { get; set; } = null!;
        public virtual DbSet<Site> Sites { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NO01NBSTROMA01\\SQLEXPRESS;Initial Catalog=MeasurementSites;Persist Security Info=True;User ID=sa;Password=admin123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasuredValue>(entity =>
            {
                entity.ToTable("MEASURED_VALUE");

                entity.Property(e => e.MeasuredValueId).ValueGeneratedNever();

                entity.Property(e => e.Quality)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.MeasuredValues)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("R_11");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.ToTable("SENSOR");

                entity.Property(e => e.SensorId).ValueGeneratedNever();

                entity.Property(e => e.SensorName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("R_27");

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Sensors)
                    .UsingEntity<Dictionary<string, object>>(
                        "SensorTag", l => l.HasOne<Tag>()
                               .WithMany()
                               .HasForeignKey("TagId")
                               .OnDelete(DeleteBehavior.ClientSetNull)
                               .HasConstraintName("R_25"),
                        r => r.HasOne<Sensor>()
                                .WithMany()
                                .HasForeignKey("SensorId")
                                .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("R_24"),
                        j =>
                        {
                            j.HasKey("SensorId", "TagId").HasName("XPKSENSOR_TAG");

                            j.ToTable("SENSOR_TAG");
                        });
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("SITE");

                entity.Property(e => e.SiteId)
                    .ValueGeneratedNever();

                entity.Property(e => e.SiteName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("TAG");

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.Quantity)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("R_5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
