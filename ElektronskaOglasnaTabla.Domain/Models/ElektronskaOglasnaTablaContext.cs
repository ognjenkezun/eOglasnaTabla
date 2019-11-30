using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElektronskaOglasnaTabla.Domain.Models
{
    public partial class ElektronskaOglasnaTablaContext : DbContext
    {
        public ElektronskaOglasnaTablaContext()
        {
        }

        public ElektronskaOglasnaTablaContext(DbContextOptions<ElektronskaOglasnaTablaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-71ITJPA\\SQLEXPRESS;Database=ElektronskaOglasnaTabla;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Announcements>(entity =>
            {
                entity.HasKey(e => e.AnnouncementId);

                entity.Property(e => e.AnnouncementDateCreated).HasColumnType("datetime");

                entity.Property(e => e.AnnouncementDateModified).HasColumnType("datetime");

                entity.Property(e => e.AnnouncementDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AnnouncementExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.AnnouncementImagePath)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.AnnouncementImportantIndicator)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.AnnouncementTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AnnouncementUserModified)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Announcements_Categories");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Announcements_Users");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Priorities>(entity =>
            {
                entity.HasKey(e => e.PriorityId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
