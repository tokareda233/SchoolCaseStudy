using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Repos.Interfaces
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
       List<Student> SearchByClassRoomId(int id);

    }
}
