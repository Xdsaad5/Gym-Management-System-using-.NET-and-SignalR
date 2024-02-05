using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GYM.NET;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainerImage> TrainerImages { get; set; }

    public virtual DbSet<TrainerVideo> TrainerVideos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=myDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student__3214EC07E2125126");

            entity.ToTable("student");

            entity.Property(e => e.Cgpa).HasColumnName("cgpa");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.University)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("university");
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("pk_trainee");

            entity.ToTable("trainee");

            entity.HasIndex(e => e.Email, "UQ__trainee__AB6E6164CF1D79A3").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__trainee__F3DBC572550176CF").IsUnique();

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Age)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("age");
            entity.Property(e => e.AssignedTrainer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("assigned_trainer");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.AssignedTrainerNavigation).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.AssignedTrainer)
                .HasConstraintName("fk_assgn_trainer");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("pk_trainer");

            entity.ToTable("Trainer");

            entity.HasIndex(e => e.Email, "UQ__Trainer__AB6E6164921DD469").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ConsultFee).HasColumnName("consult_fee");
            entity.Property(e => e.Experience)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("experience");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParticipatedInAnyCompetition)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("participated_in_any_competition");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Speciality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<TrainerImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_trainerImages");

            entity.ToTable("trainerImages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_url");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.TrainerImages)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_trainerImages");
        });

        modelBuilder.Entity<TrainerVideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_trainerVideos");

            entity.ToTable("trainerVideos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("video_url");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.TrainerVideos)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_trainerVideos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
