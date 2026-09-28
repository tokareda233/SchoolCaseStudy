using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

       
        [Required]
        public int StudentId { get; set; }

      
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal Grade { get; set; }

        
        public Student ?Student { get; set; }

        public Subject ?Subject { get; set; }
    }
}
