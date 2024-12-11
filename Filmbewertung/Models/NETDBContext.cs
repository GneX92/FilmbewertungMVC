using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Filmbewertung.Models
{
    public partial class NETDBContext : DbContext
    {
        public NETDBContext()
        {
        }

        public NETDBContext(DbContextOptions<NETDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Film { get; set; } = null!;
        public virtual DbSet<FilmAbstimmung> FilmAbstimmung { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.\\SQLEXPRESS;Database=NETDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("Film");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Titel)
                    .HasMaxLength(100)
                    .HasColumnName("TITEL");
            });

            modelBuilder.Entity<FilmAbstimmung>(entity =>
            {
                entity.ToTable("FilmAbstimmung");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.Note).HasMaxLength(15);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmAbstimmung)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_FILM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
