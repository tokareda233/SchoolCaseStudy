using SchoolCaseStudy.Data;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.Interfaces;
using SchoolCaseStudy.Repos.Repository;

namespace SchoolCaseStudy.Repos.Implmentation
{
    public class StudentRepo:GenericRepo<Student>,IStudentRepo
    {
        private readonly AppDbContext _context;
        
        public StudentRepo(AppDbContext context) : base(context) { 
        
            _context = context;
        }

        public List<Student> SearchByClassRoomId(int id)
        {
           var stu = _context.Students.Where(x=>x.ClassRoomId == id).ToList();
            return stu;
            
        }
    }
}
