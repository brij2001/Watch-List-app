using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProjectMangukiyaBrijMukesh;

public partial class Bmangukiya1Context : DbContext
{


    public Bmangukiya1Context(DbContextOptions<Bmangukiya1Context> options)
        : base(options)
    {
    }


    public virtual DbSet<TblGenre> TblGenres { get; set; }

    public virtual DbSet<TblWatchList> TblWatchLists { get; set; }

    public virtual DbSet<TblWatchListItem> TblWatchListItems { get; set; }

    public IConfiguration myconfig { get; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=10.22.13.242; Initial Catalog =BMangukiya1 ; User ID= bmangukiya1 ; Password = H703226129 ; TrustServerCertificate = True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<TblGenre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__tblGenre__0385055ED8E78410");

            entity.ToTable("tblGenre");

            entity.HasIndex(e => e.Name, "UQ__tblGenre__737584F69F57908E").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TblWatchList>(entity =>
        {
            entity.HasKey(e => e.ListId).HasName("PK__tblWatch__E3832865A171F297");

            entity.ToTable("tblWatchList");

            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TblWatchListItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__tblWatch__727E83EBF93A8D7B");

            entity.ToTable("tblWatchListItems");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.MediaId)
                .HasMaxLength(255)
                .HasColumnName("MediaID");
            entity.Property(e => e.MediaType).HasMaxLength(50);

            entity.HasOne(d => d.Genre).WithMany(p => p.TblWatchListItems)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__tblWatchL__Genre__6B24EA82");

            entity.HasOne(d => d.List).WithMany(p => p.TblWatchListItems)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblWatchL__ListI__6A30C649");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
