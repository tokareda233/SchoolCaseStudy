using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.DTOs
{
    public class GetStudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

       
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        
        public DateTime DateOfBirth { get; set; }
        public int ClassRoomId { get; set; }
    }
}
