using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.DTOs
{
    public class GetClassRoomDTO
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

        public int GradeLevel { get; set; }

        public int Capacity { get; set; }
    }
}
