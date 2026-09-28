using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Models
{
    public class Student
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
        public DateTime DateOfBirth { get; set; }

        
        [Required]
        public int ClassRoomId { get; set; }

        
        public ClassRoom? ClassRoom { get; set; }

        
        public ICollection<Enrollment> ?Enrollments { get; set; } = new List<Enrollment>();
    }
}
