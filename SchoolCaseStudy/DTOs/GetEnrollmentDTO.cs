using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.DTOs
{
    public class GetEnrollmentDTO
    {

        public int Id { get; set; }


       
        public int StudentId { get; set; }


        
        public int SubjectId { get; set; }

       
        public DateTime EnrollmentDate { get; set; }

       
        public decimal Grade { get; set; }

    }
}
