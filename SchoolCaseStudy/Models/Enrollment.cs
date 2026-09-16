using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        // Foreign Key
        [Required]
        public int StudentId { get; set; }

        // Foreign Key
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal Grade { get; set; }

        // Navigation Properties
        public Student Student { get; set; }

        public Subject Subject { get; set; }
    }
}
