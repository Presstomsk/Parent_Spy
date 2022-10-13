using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parent_Spy.Models;

#nullable disable

namespace Parent_Spy.DataBase
{
    public partial class PlacesContext : DbContext
    {
        public PlacesContext()
        {
        }

        public PlacesContext(DbContextOptions<PlacesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MozAnno> MozAnnos { get; set; }
        public virtual DbSet<MozAnnoAttribute> MozAnnoAttributes { get; set; }       
        public virtual DbSet<MozOrigin> MozOrigins { get; set; }
        public virtual DbSet<MozPlace> MozPlaces { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["ConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MozAnno>(entity =>
            {
                entity.ToTable("moz_annos");

                entity.HasIndex(e => new { e.PlaceId, e.AnnoAttributeId }, "moz_annos_placeattributeindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AnnoAttributeId).HasColumnName("anno_attribute_id");

                entity.Property(e => e.Content)
                    .HasColumnType("LONGVARCHAR")
                    .HasColumnName("content");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("dateAdded")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Expiration)
                    .HasColumnName("expiration")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.MozAnnos)
                    .HasForeignKey(d => d.PlaceId);
            });

            modelBuilder.Entity<MozAnnoAttribute>(entity =>
            {
                entity.ToTable("moz_anno_attributes");

                entity.HasIndex(e => e.Name, "IX_moz_anno_attributes_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(32)")
                    .HasColumnName("name");
            });           

            modelBuilder.Entity<MozOrigin>(entity =>
            {
                entity.ToTable("moz_origins");

                entity.HasIndex(e => new { e.Prefix, e.Host }, "IX_moz_origins_prefix_host")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Frecency).HasColumnName("frecency");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasColumnName("host");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasColumnName("prefix");
            });

            modelBuilder.Entity<MozPlace>(entity =>
            {
                entity.ToTable("moz_places");

                entity.HasIndex(e => e.Frecency, "moz_places_frecencyindex");

                entity.HasIndex(e => e.Guid, "moz_places_guid_uniqueindex")
                    .IsUnique();

                entity.HasIndex(e => e.RevHost, "moz_places_hostindex");

                entity.HasIndex(e => e.LastVisitDate, "moz_places_lastvisitdateindex");

                entity.HasIndex(e => e.OriginId, "moz_places_originidindex");

                entity.HasIndex(e => e.UrlHash, "moz_places_url_hashindex");

                entity.HasIndex(e => e.VisitCount, "moz_places_visitcount");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ForeignCount).HasColumnName("foreign_count");

                entity.Property(e => e.Frecency)
                    .HasColumnName("frecency")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Guid).HasColumnName("guid");

                entity.Property(e => e.Hidden).HasColumnName("hidden");

                entity.Property(e => e.LastVisitDate).HasColumnName("last_visit_date");

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.Property(e => e.PreviewImageUrl).HasColumnName("preview_image_url");

                entity.Property(e => e.RevHost)
                    .HasColumnType("LONGVARCHAR")
                    .HasColumnName("rev_host");

                entity.Property(e => e.SiteName).HasColumnName("site_name");

                entity.Property(e => e.Title)
                    .HasColumnType("LONGVARCHAR")
                    .HasColumnName("title");

                entity.Property(e => e.Typed).HasColumnName("typed");

                entity.Property(e => e.Url)
                    .HasColumnType("LONGVARCHAR")
                    .HasColumnName("url");

                entity.Property(e => e.UrlHash).HasColumnName("url_hash");

                entity.Property(e => e.VisitCount)
                    .HasColumnName("visit_count")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.MozPlaces)
                    .HasForeignKey(d => d.OriginId);
            });            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
