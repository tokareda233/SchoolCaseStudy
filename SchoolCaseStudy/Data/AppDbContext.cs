using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
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
            
           
            modelBuilder.Entity<Teacher>() 
            .HasOne(t => t.Department) 
            .WithMany(d => d.Teachers) 
            .HasForeignKey(t => t.DepartmentId) 
            .OnDelete(DeleteBehavior.Restrict); 
           
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
            
            
            
            modelBuilder.Entity<Subject>() 
            .HasOne(s => s.Teacher) 
            .WithMany(t => t.Subjects) 
            .HasForeignKey(s => s.TeacherId) 
            .OnDelete(DeleteBehavior.Restrict); 
            
          
            
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
            
            
            modelBuilder.Entity<Student>() 
            .HasOne(s => s.ClassRoom) 
            .WithMany(c => c.Students) 
            .HasForeignKey(s => s.ClassRoomId) 
            .OnDelete(DeleteBehavior.Restrict); 
            
           
            modelBuilder.Entity<Enrollment>() 
            .HasKey(e => e.Id); 

            modelBuilder.Entity<Enrollment>() 
            .Property(e => e.EnrollmentDate) 
            .IsRequired();
            
            modelBuilder.Entity<Enrollment>() 
            .Property(e => e.Grade) 
            .HasColumnType("decimal(5,2)") 
            .IsRequired(); 
            
           
            modelBuilder.Entity<Enrollment>() 
            .HasOne(e => e.Student) 
            .WithMany(s => s.Enrollments) 
            .HasForeignKey(e => e.StudentId) 
            .OnDelete(DeleteBehavior.Cascade); 
            
           
            
            modelBuilder.Entity<Enrollment>() 
            .HasOne(e => e.Subject) 
            .WithMany(s => s.Enrollments) 
            .HasForeignKey(e => e.SubjectId) 
            .OnDelete(DeleteBehavior.Cascade); 
            
            
            modelBuilder.Entity<Enrollment>() 
            .HasIndex(e => new { e.StudentId, e.SubjectId }) .IsUnique(); 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom
                {
                    Id = 1,
                    Name = "Class 1A",
                    GradeLevel = 1,
                    Capacity = 30
                },
                new ClassRoom
                {
                    Id = 2,
                    Name = "Class 2A",
                    GradeLevel = 2,
                    Capacity = 30
                },
                new ClassRoom
                {
                    Id = 3,
                    Name = "Class 3A",
                    GradeLevel = 3,
                    Capacity = 35
                }
            );

            
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Mathematics",
                    Description = "Mathematics Department"
                },
                new Department
                {
                    Id = 2,
                    Name = "Science",
                    Description = "Science Department"
                },
                new Department
                {
                    Id = 3,
                    Name = "Languages",
                    Description = "Languages Department"
                }
            );

           
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Hassan",
                    Email = "ahmed.hassan@school.com",
                    DepartmentId = 1
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Sara",
                    LastName = "Ali",
                    Email = "sara.ali@school.com",
                    DepartmentId = 2
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Mohamed",
                    Email = "omar.mohamed@school.com",
                    DepartmentId = 3
                }
            );

            
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Mathematics",
                    Description = "Basic Mathematics",
                    MaxGrade = 100,
                    TeacherId = 1
                },
                new Subject
                {
                    Id = 2,
                    Name = "Science",
                    Description = "General Science",
                    MaxGrade = 100,
                    TeacherId = 2
                },
                new Subject
                {
                    Id = 3,
                    Name = "English",
                    Description = "English Language",
                    MaxGrade = 100,
                    TeacherId = 3
                }
            );

           
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Youssef",
                    LastName = "Ahmed",
                    Email = "youssef.ahmed@student.com",
                    PhoneNumber = "01012345678",
                    DateOfBirth = new DateTime(2015, 5, 10),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Mariam",
                    LastName = "Hassan",
                    Email = "mariam.hassan@student.com",
                    PhoneNumber = "01123456789",
                    DateOfBirth = new DateTime(2015, 8, 20),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Adam",
                    LastName = "Mohamed",
                    Email = "adam.mohamed@student.com",
                    PhoneNumber = "01234567890",
                    DateOfBirth = new DateTime(2014, 3, 15),
                    ClassRoomId = 2
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Laila",
                    LastName = "Ali",
                    Email = "laila.ali@student.com",
                    PhoneNumber = "01098765432",
                    DateOfBirth = new DateTime(2014, 11, 5),
                    ClassRoomId = 2
                }
            );

            
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 85
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 1,
                    SubjectId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 90
                },
                new Enrollment
                {
                    Id = 3,
                    StudentId = 2,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 95
                },
                new Enrollment
                {
                    Id = 4,
                    StudentId = 2,
                    SubjectId = 3,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 88
                },
                new Enrollment
                {
                    Id = 5,
                    StudentId = 3,
                    SubjectId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 78
                },
                new Enrollment
                {
                    Id = 6,
                    StudentId = 4,
                    SubjectId = 3,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 92
                }
            );
        }
    }
}
