using AutoMapper;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Mapping
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, GetsubjectDTO>();
            CreateMap<CreateSubjectDTO, Subject>();
        }
    }
}
