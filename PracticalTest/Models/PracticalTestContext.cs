using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticalTest.Models
{
    public partial class PracticalTestContext : DbContext
    {
        public PracticalTestContext()
        {
        }

        public PracticalTestContext(DbContextOptions<PracticalTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8S50BME\\SQL2017; Initial Catalog=PracticalTest; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.SubjectName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.SerialNumber);

                entity.Property(e => e.AvailableDate).HasColumnType("datetime");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nric)
                    .IsRequired()
                    .HasColumnName("NRIC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Users_Subjects");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
