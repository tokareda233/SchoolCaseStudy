using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Mapping;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentController(AppDbContext context)
        {
            _context = context;

            var conf = new MapperConfiguration(x =>
            {
                x.AddProfile<StudentProfile>();
            });

            _mapper = conf.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            var studentDTOs = _mapper.Map<List<GetStudentDTO>>(students);

            return Ok(studentDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _context.Students
                .FirstOrDefault(a => a.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = _mapper.Map<GetStudentDTO>(student);

            return Ok(studentDTO);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO student) {


            if (student == null)
            {
                return BadRequest();
            }

            var classroom = _context.ClassRooms
                .Any(a => a.Id == student.ClassRoomId);

            if (!classroom)
            {
                return BadRequest("The Classroom does not exist");
            }
            var dto=_mapper.Map<Student>(student);
            _context.Students.Add(dto);
            _context.SaveChanges();

           

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, CreateStudentDTO studto)
        {
            var student = _context.Students
                .FirstOrDefault(a => a.Id == id);

            if (student == null)
            {
                return NotFound("The student was not found");
            }

            var classroom = _context.ClassRooms
                .Any(a => a.Id == studto.ClassRoomId);

            if (!classroom)
            {
                return BadRequest("The Classroom does not exist");
            }

            _mapper.Map(studto, student);

            _context.SaveChanges();

            return Ok(studto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students
                .FirstOrDefault(a => a.Id == id);

            if (student == null)
            {
                return NotFound("The student was not found");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok(student);

        }
    }
}
