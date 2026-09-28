using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}


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

            // ==================== Seed Data ====================

            // Departments
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Computer Science",
                    Description = "Department of Computer Science"
                },
                new Department
                {
                    Id = 2,
                    Name = "Information Technology",
                    Description = "Department of Information Technology"
                }
            );


            // Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Hassan",
                    Email = "ahmed.hassan@school.com",
                    PhoneNumber = "01012345678",
                    Salary = 15000,
                    DepartmentId = 1
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Mona",
                    LastName = "Ali",
                    Email = "mona.ali@school.com",
                    PhoneNumber = "01112345678",
                    Salary = 14000,
                    DepartmentId = 1
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Ibrahim",
                    Email = "omar.ibrahim@school.com",
                    PhoneNumber = "01212345678",
                    Salary = 13000,
                    DepartmentId = 2
                }
            );


            // Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "C# Programming",
                    Description = "Introduction to C# programming",
                    MaxGrade = 100,
                    TeacherId = 1
                },
                new Subject
                {
                    Id = 2,
                    Name = "Database",
                    Description = "Database concepts and SQL",
                    MaxGrade = 100,
                    TeacherId = 2
                },
                new Subject
                {
                    Id = 3,
                    Name = "Web Development",
                    Description = "HTML, CSS and web development",
                    MaxGrade = 100,
                    TeacherId = 3
                }
            );


            // ClassRooms
            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom
                {
                    Id = 1,
                    Name = "Class A",
                    GradeLevel = 10,
                    Capacity = 30
                },
                new ClassRoom
                {
                    Id = 2,
                    Name = "Class B",
                    GradeLevel = 11,
                    Capacity = 25
                },
                new ClassRoom
                {
                    Id = 3,
                    Name = "Class C",
                    GradeLevel = 12,
                    Capacity = 30
                }
            );


            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Mohamed",
                    Email = "ali.mohamed@student.com",
                    PhoneNumber = "01011111111",
                    DateOfBirth = new DateTime(2009, 5, 10),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Sara",
                    LastName = "Ahmed",
                    Email = "sara.ahmed@student.com",
                    PhoneNumber = "01122222222",
                    DateOfBirth = new DateTime(2009, 8, 15),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Youssef",
                    LastName = "Mahmoud",
                    Email = "youssef.mahmoud@student.com",
                    PhoneNumber = "01233333333",
                    DateOfBirth = new DateTime(2008, 3, 20),
                    ClassRoomId = 2
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Nour",
                    LastName = "Khaled",
                    Email = "nour.khaled@student.com",
                    PhoneNumber = "01044444444",
                    DateOfBirth = new DateTime(2008, 11, 5),
                    ClassRoomId = 2
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Mariam",
                    LastName = "Tarek",
                    Email = "mariam.tarek@student.com",
                    PhoneNumber = "01155555555",
                    DateOfBirth = new DateTime(2007, 7, 12),
                    ClassRoomId = 3
                }
            );


            // Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 90
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 1,
                    SubjectId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 85
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
                    StudentId = 3,
                    SubjectId = 3,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 82
                },
                new Enrollment
                {
                    Id = 7,
                    StudentId = 4,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 91
                },
                new Enrollment
                {
                    Id = 8,
                    StudentId = 5,
                    SubjectId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 87
                }
            );
        }
    }
}
