using AutoMapper;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Mapping
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentDTO>();
            

            CreateMap<CreateStudentDTO, Student>()
                .ForMember(des => des.FirstName,
                opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)[0]))

                .ForMember(des => des.LastName,
                opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)[1]));
        }
    }
}
