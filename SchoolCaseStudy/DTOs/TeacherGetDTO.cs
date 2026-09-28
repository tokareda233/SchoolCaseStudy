using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.DTOs
{
    public class TeacherGetDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }



        public string Email { get; set; }

        
        public string? PhoneNumber { get; set; }

       
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
