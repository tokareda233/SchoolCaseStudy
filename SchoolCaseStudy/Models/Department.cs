using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        // One Department → Many Teachers
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
