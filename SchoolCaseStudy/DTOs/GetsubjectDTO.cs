using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.DTOs
{
    public class GetsubjectDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public int MaxGrade { get; set; }

        public int TeacherId { get; set; }

    }
}
