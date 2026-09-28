using AutoMapper;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Mapping
{
    public class EnrollmentProfile:Profile
    {
        public EnrollmentProfile() {


            CreateMap<Enrollment, GetEnrollmentDTO>();
            CreateMap<CreateEnrollmentDTO, Enrollment>();
        }
    }
}
