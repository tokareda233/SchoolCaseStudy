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

       
        [Required]
        public int DepartmentId { get; set; }

       
        public Department ?Department { get; set; }

      
        public ICollection<Subject> ?Subjects { get; set; } = new List<Subject>();
    }
}
