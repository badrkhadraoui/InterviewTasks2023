using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InterviewTasks2023.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Rack> Racks { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Rack>(entity =>
        {
            entity.HasKey(e => e.RackId).HasName("PK__Racks__0363DAA80D2A571E");

            entity.Property(e => e.RackId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.HasKey(e => e.ShelfId).HasName("PK__Shelves__DBD04F07880E34B0");

            entity.Property(e => e.ShelfId).ValueGeneratedNever();

            entity.HasOne(d => d.Rack).WithMany(p => p.Shelves)
                .HasForeignKey(d => d.RackId)
                .HasConstraintName("FK__Shelves__RackId__4E88ABD4");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Books__A25C5AA6EFC81581");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BookName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Shelf).WithMany(p => p.Books)
                .HasForeignKey(d => d.ShelfId)
                .HasConstraintName("FK__Books__ShelfId__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
