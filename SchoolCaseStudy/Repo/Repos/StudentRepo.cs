using AutoMapper;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repo.Interfaces;

namespace SchoolCaseStudy.Repo.Repos
{
    public class StudentRepo : IStudentRepo
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public void AddStudent(CreateStudentDTO student)
        {
          var stu= _mapper.Map<Student>(student);
            _context.Students.Add(stu);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
           var stu =_context.Students.FirstOrDefault(x => x.Id == id);
           
            _context.Students.Remove(stu);
            _context.SaveChanges();
        }

        public GetStudentDTO GetStudent(int id)
        {
            var stu = _context.Students.FirstOrDefault(x => x.Id == id);
            if (stu == null)
            {
                return null;
            }
            var dto = _mapper.Map<GetStudentDTO>(stu);
            return dto;
        }

        public List<GetStudentDTO> GetStudents()
        {
            var stu = _context.Students.ToList();
            var dto = _mapper.Map<List<GetStudentDTO>>(stu);
            return dto;
        }

        public void UpdateStudent(int id, CreateStudentDTO student)
        {
            var stu = _context.Students.FirstOrDefault(x => x.Id == id);
           
            _mapper.Map(student,stu );
          
            _context.SaveChanges();
        }
    }
}
