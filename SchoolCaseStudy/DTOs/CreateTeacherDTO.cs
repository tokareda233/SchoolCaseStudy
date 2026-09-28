namespace SchoolCaseStudy.DTOs
{
    public class CreateTeacherDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }


        public string? PhoneNumber { get; set; }


        public decimal Salary { get; set; }



        public int DepartmentId { get; set; }
    }
}
