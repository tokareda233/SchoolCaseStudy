using AutoMapper;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile(){

            CreateMap<Department, GetDepDto>();
            CreateMap<CreateDepDto, Department>();

        }
    }
}
