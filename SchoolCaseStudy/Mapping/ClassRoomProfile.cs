using AutoMapper;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Mapping
{
    public class ClassRoomProfile:Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<ClassRoom, GetClassRoomDTO>();
            CreateMap<CreateClassRoomDTO, ClassRoom>();
        }
       
    }
}
