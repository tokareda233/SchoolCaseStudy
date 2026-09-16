using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(1, 100)]
        public int MaxGrade { get; set; }

        // Foreign Key
        [Required]
        public int TeacherId { get; set; }

        // Navigation Property
        public Teacher Teacher { get; set; }

        // One Subject → Many Enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
