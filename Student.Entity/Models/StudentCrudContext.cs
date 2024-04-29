using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student.Entity.Models;

public partial class StudentCrudContext : DbContext
{
    //public object Studentdetail;

    public StudentCrudContext()
    {
    }

    public StudentCrudContext(DbContextOptions<StudentCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Markdetail> Markdetails { get; set; }

    public virtual DbSet<Studentdetail> Studentdetails { get; set; }


    //------------------------------------
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Scaffolding
        => optionsBuilder.UseSqlServer("Server=SALONY;Initial Catalog=studentCRUD; User Id=sa; password=root;Persist Security Info=False;Integrated Security=false;TrustServerCertificate=True;");
    //------------------------------------


   // to define one to many relation
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Markdetail>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK_AddressMaster");

            entity.ToTable("markdetails");

            entity.Property(e => e.SubjectId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //.HasOne . WithMany .HasForeignKey
            entity.HasOne(d => d.Student).WithMany(p => p.Markdetails)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_markdetails_studentdetails");
        });

        modelBuilder.Entity<Studentdetail>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_tudentdetails");

            entity.ToTable("studentdetails");

            entity.Property(e => e.StudentId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
