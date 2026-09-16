using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS04;Initial Catalog=SchoolAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ========================= // Department // =========================
            modelBuilder.Entity<Department>() 
            .HasKey(d => d.Id);

            modelBuilder.Entity<Department>() 
            .Property(d => d.Name) 
            .IsRequired() 
            .HasMaxLength(100); 

            modelBuilder.Entity<Department>() 
            .Property(d => d.Description) 
            .HasMaxLength(500) 
            .IsRequired(false);
            // ========================= // Teacher // =========================
            modelBuilder.Entity<Teacher>() 
            .HasKey(t => t.Id); 
            
            modelBuilder.Entity<Teacher>() 
            .Property(t => t.FirstName) 
            .IsRequired() 
            .HasMaxLength(50); 
            
            modelBuilder.Entity<Teacher>() 
            .Property(t => t.LastName) 
            .IsRequired() 
            .HasMaxLength(50); 
            
            modelBuilder.Entity<Teacher>() 
            .Property(t => t.Email) 
            .IsRequired() 
            .HasMaxLength(150);
            
            modelBuilder.Entity<Teacher>() 
            .Property(t => t.PhoneNumber) 
            .HasMaxLength(20) 
            .IsRequired(false); 
            
            modelBuilder.Entity<Teacher>() 
            .Property(t => t.Salary) 
            .IsRequired() 
            .HasColumnType("decimal(18,2)"); 
            
            // Department → Teacher
            modelBuilder.Entity<Teacher>() 
            .HasOne(t => t.Department) 
            .WithMany(d => d.Teachers) 
            .HasForeignKey(t => t.DepartmentId) 
            .OnDelete(DeleteBehavior.Restrict); 
            // ========================= // Subject // =========================
            modelBuilder.Entity<Subject>() 
            .HasKey(s => s.Id); 
            
            modelBuilder.Entity<Subject>() 
            .Property(s => s.Name) 
            .IsRequired() 
            .HasMaxLength(100); 
            
            modelBuilder.Entity<Subject>() 
            .Property(s => s.Description) 
            .HasMaxLength(500) 
            .IsRequired(false); 
            
            modelBuilder.Entity<Subject>() 
            .Property(s => s.MaxGrade) 
            .IsRequired();
            
            // Teacher → Subject
            
            modelBuilder.Entity<Subject>() 
            .HasOne(s => s.Teacher) 
            .WithMany(t => t.Subjects) 
            .HasForeignKey(s => s.TeacherId) 
            .OnDelete(DeleteBehavior.Restrict); 
            
            // ========================= // ClassRoom // =========================
            
            modelBuilder.Entity<ClassRoom>() 
            .HasKey(c => c.Id);
            
            modelBuilder.Entity<ClassRoom>() 
            .Property(c => c.Name) 
            .IsRequired() 
            .HasMaxLength(50); 
            

            modelBuilder.Entity<ClassRoom>() 
            .Property(c => c.GradeLevel) 
            .IsRequired(); 

            modelBuilder.Entity<ClassRoom>() 
            .Property(c => c.Capacity) 
            .IsRequired(); 
            
            
            // ========================= // Student // =========================
            modelBuilder.Entity<Student>() 
             .HasKey(s => s.Id); 
            
            modelBuilder.Entity<Student>() 
             .Property(s => s.FirstName) 
             .IsRequired() 
             .HasMaxLength(50); 
            
            modelBuilder.Entity<Student>() 
            .Property(s => s.LastName) 
            .IsRequired() 
            .HasMaxLength(50);
            
            modelBuilder.Entity<Student>() 
            .Property(s => s.Email) 
            .IsRequired() 
            .HasMaxLength(150); 
            
            modelBuilder.Entity<Student>() 
            .Property(s => s.PhoneNumber) 
            .HasMaxLength(20) 
            .IsRequired(false);
            
            modelBuilder.Entity<Student>() 
            .Property(s => s.DateOfBirth) 
            .IsRequired(); 
            
            // ClassRoom → Student
            modelBuilder.Entity<Student>() 
            .HasOne(s => s.ClassRoom) 
            .WithMany(c => c.Students) 
            .HasForeignKey(s => s.ClassRoomId) 
            .OnDelete(DeleteBehavior.Restrict); 
            
            // ========================= // Enrollment // =========================
            modelBuilder.Entity<Enrollment>() 
            .HasKey(e => e.Id); 

            modelBuilder.Entity<Enrollment>() 
            .Property(e => e.EnrollmentDate) 
            .IsRequired();
            
            modelBuilder.Entity<Enrollment>() 
            .Property(e => e.Grade) 
            .HasColumnType("decimal(5,2)") 
            .IsRequired(); 
            
            // Student → Enrollment
            modelBuilder.Entity<Enrollment>() 
            .HasOne(e => e.Student) 
            .WithMany(s => s.Enrollments) 
            .HasForeignKey(e => e.StudentId) 
            .OnDelete(DeleteBehavior.Cascade); 
            
            // Subject → Enrollment
            
            modelBuilder.Entity<Enrollment>() 
            .HasOne(e => e.Subject) 
            .WithMany(s => s.Enrollments) 
            .HasForeignKey(e => e.SubjectId) 
            .OnDelete(DeleteBehavior.Cascade); 
            
            // ========================= // Prevent duplicate enrollment // =========================
            modelBuilder.Entity<Enrollment>() 
            .HasIndex(e => new { e.StudentId, e.SubjectId }) .IsUnique(); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
