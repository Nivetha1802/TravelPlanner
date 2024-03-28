using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TravelPlanner.Entities;

public partial class TpContext : DbContext
{
    public TpContext()
    {
    }

    public TpContext(DbContextOptions<TpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Membersdetail> Membersdetails { get; set; }

    public virtual DbSet<Placesdetail> Placesdetails { get; set; }

    public virtual DbSet<Tripdetail> Tripdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Expenseid).HasName("PRIMARY");

            entity.ToTable("expenses");

            entity.HasIndex(e => e.Placeid, "placeid");

            entity.HasIndex(e => e.Userid, "userid");

            entity.Property(e => e.Expenseid).HasColumnName("expenseid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Expensestype)
                .HasColumnType("text")
                .HasColumnName("expensestype");
            entity.Property(e => e.Modifiedat)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Placeid).HasColumnName("placeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Place).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.Placeid)
                .HasConstraintName("expenses_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("expenses_ibfk_1");
        });

        modelBuilder.Entity<Membersdetail>(entity =>
        {
            entity.HasKey(e => e.Memberid).HasName("PRIMARY");

            entity.ToTable("membersdetails");

            entity.HasIndex(e => e.Userid, "userid");

            entity.Property(e => e.Memberid).HasColumnName("memberid");
            entity.Property(e => e.Memberage).HasColumnName("memberage");
            entity.Property(e => e.Membername)
                .HasColumnType("text")
                .HasColumnName("membername");
            entity.Property(e => e.Membertype)
                .HasColumnType("text")
                .HasColumnName("membertype");
            entity.Property(e => e.Modifiedat)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Membersdetails)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("membersdetails_ibfk_1");
        });

        modelBuilder.Entity<Placesdetail>(entity =>
        {
            entity.HasKey(e => e.Placeid).HasName("PRIMARY");

            entity.ToTable("placesdetails");

            entity.HasIndex(e => e.Userid, "userid");

            entity.Property(e => e.Placeid).HasColumnName("placeid");
            entity.Property(e => e.Modifiedat)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Placename)
                .HasColumnType("text")
                .HasColumnName("placename");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Placesdetails)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("placesdetails_ibfk_1");
        });

        modelBuilder.Entity<Tripdetail>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");

            entity.ToTable("tripdetails");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Addnotes)
                .HasMaxLength(255)
                .HasColumnName("addnotes");
            entity.Property(e => e.Arrivalday).HasColumnName("arrivalday");
            entity.Property(e => e.Budget)
                .HasPrecision(10, 2)
                .HasColumnName("budget");
            entity.Property(e => e.Departureday).HasColumnName("departureday");
            entity.Property(e => e.Destinationplace)
                .HasColumnType("text")
                .HasColumnName("destinationplace");
            entity.Property(e => e.Durationoftrip).HasColumnName("durationoftrip");
            entity.Property(e => e.Modeoftransport)
                .HasColumnType("enum('bus','train','walk','plane','car','bike')")
                .HasColumnName("modeoftransport");
            entity.Property(e => e.Modifiedat)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Originplace)
                .HasColumnType("text")
                .HasColumnName("originplace");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
