using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        // Foreign Key
        [Required]
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department Department { get; set; }

        // One Teacher → Many Subjects
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
