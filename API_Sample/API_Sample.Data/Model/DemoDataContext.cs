using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Sample.Data.Model;

public partial class DemoDataContext : DbContext
{
    public DemoDataContext()
    {
    }

    public DemoDataContext(DbContextOptions<DemoDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeMapsClass> EmployeeMapsClasses { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentMapsClass> StudentMapsClasses { get; set; }

    public virtual DbSet<StudentMapsTuition> StudentMapsTuitions { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Tuition> Tuitions { get; set; }

    public virtual DbSet<TuitionTransaction> TuitionTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\TESTDB;Database=Demo_data;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("attendances");

            entity.HasIndex(e => e.ClassId, "IX_attendances_ClassId");

            entity.HasIndex(e => e.StudentId, "IX_attendances_StudentId");

            entity.HasOne(d => d.Class).WithMany(p => p.Attendances).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("classes");

            entity.HasIndex(e => e.GradeId, "IX_classes_GradeId");

            entity.HasIndex(e => e.SubjectId, "IX_classes_SubjectId");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classes).HasForeignKey(d => d.GradeId);

            entity.HasOne(d => d.Subject).WithMany(p => p.Classes).HasForeignKey(d => d.SubjectId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.HasIndex(e => e.RoleId, "IX_employees_RoleId");

            entity.HasIndex(e => e.SubjectId, "IX_employees_SubjectId");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.Subject).WithMany(p => p.Employees).HasForeignKey(d => d.SubjectId);
        });

        modelBuilder.Entity<EmployeeMapsClass>(entity =>
        {
            entity.ToTable("employeeMapsClasses");

            entity.HasIndex(e => e.ClassId, "IX_employeeMapsClasses_ClassId");

            entity.HasIndex(e => e.EmployeeId, "IX_employeeMapsClasses_EmployeeId");

            entity.HasOne(d => d.Class).WithMany(p => p.EmployeeMapsClasses).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeMapsClasses).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("grades");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("students");

            entity.HasIndex(e => e.RoleId, "IX_students_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Students).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<StudentMapsClass>(entity =>
        {
            entity.ToTable("studentMapsClasses");

            entity.HasIndex(e => e.ClassId, "IX_studentMapsClasses_ClassId");

            entity.HasIndex(e => e.StudentId, "IX_studentMapsClasses_StudentId");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentMapsClasses).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Student).WithMany(p => p.StudentMapsClasses).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<StudentMapsTuition>(entity =>
        {
            entity.ToTable("studentMapsTuitions");

            entity.HasIndex(e => e.ClassId, "IX_studentMapsTuitions_ClassId");

            entity.HasIndex(e => e.StudentId, "IX_studentMapsTuitions_StudentId");

            entity.HasIndex(e => e.TuitionId, "IX_studentMapsTuitions_TuitionId");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentMapsTuitions).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Student).WithMany(p => p.StudentMapsTuitions).HasForeignKey(d => d.StudentId);

            entity.HasOne(d => d.Tuition).WithMany(p => p.StudentMapsTuitions).HasForeignKey(d => d.TuitionId);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("subjects");
        });

        modelBuilder.Entity<Tuition>(entity =>
        {
            entity.ToTable("tuitions");
        });

        modelBuilder.Entity<TuitionTransaction>(entity =>
        {
            entity.ToTable("tuitionTransactions");

            entity.HasIndex(e => e.ClassId, "IX_tuitionTransactions_ClassId");

            entity.HasIndex(e => e.StudentId, "IX_tuitionTransactions_StudentId");

            entity.Property(e => e.ClassMonth).HasColumnName("classMonth");
            entity.Property(e => e.ClassYear).HasColumnName("classYear");

            entity.HasOne(d => d.Class).WithMany(p => p.TuitionTransactions).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Student).WithMany(p => p.TuitionTransactions).HasForeignKey(d => d.StudentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
