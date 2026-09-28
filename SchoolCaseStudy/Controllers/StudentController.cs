using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Mapping;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repo.Interfaces;

namespace SchoolCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }


        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentRepo.GetStudents();

            return Ok(students);
        }


       
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentRepo.GetStudent(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }


        
        [HttpPost]
        public IActionResult AddStudent(CreateStudentDTO studentDTO)
        {
            _studentRepo.AddStudent(studentDTO);

            return Ok("Student addeddddd");
        }


       
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, CreateStudentDTO studentDTO)
        {
            var student = _studentRepo.GetStudent(id);

            if (student == null)
                return NotFound();

            _studentRepo.UpdateStudent(id, studentDTO);

            return Ok("Student updatedddd");
        }


      
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentRepo.GetStudent(id);

            if (student == null)
                return NotFound();

            _studentRepo.DeleteStudent(id);

            return Ok("Student deleteddddd");
        }


        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        //public StudentController(AppDbContext context, IMapper mapper)
        //{
        //    _context = context;

        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public IActionResult GetAllStudents()
        //{
        //    var students = _context.Students.ToList();
        //    var studentDTOs = _mapper.Map<List<GetStudentDTO>>(students);

        //    return Ok(studentDTOs);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Student> GetStudent(int id)
        //{
        //    var student = _context.Students
        //        .FirstOrDefault(a => a.Id == id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentDTO = _mapper.Map<GetStudentDTO>(student);

        //    return Ok(studentDTO);
        //}

        //[HttpPost]
        //public IActionResult CreateStudent(CreateStudentDTO student) {


        //    if (student == null)
        //    {
        //        return BadRequest();
        //    }

        //    var classroom = _context.ClassRooms
        //        .Any(a => a.Id == student.ClassRoomId);

        //    if (!classroom)
        //    {
        //        return BadRequest("The Classroom does not exist");
        //    }
        //    var dto=_mapper.Map<Student>(student);
        //    _context.Students.Add(dto);
        //    _context.SaveChanges();



        //    return Ok(dto);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateStudent(int id, CreateStudentDTO studto)
        //{
        //    var student = _context.Students
        //        .FirstOrDefault(a => a.Id == id);

        //    if (student == null)
        //    {
        //        return NotFound("The student was not found");
        //    }

        //    var classroom = _context.ClassRooms
        //        .Any(a => a.Id == studto.ClassRoomId);

        //    if (!classroom)
        //    {
        //        return BadRequest("The Classroom does not exist");
        //    }

        //    _mapper.Map(studto, student);

        //    _context.SaveChanges();

        //    return Ok(studto);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = _context.Students
        //        .FirstOrDefault(a => a.Id == id);

        //    if (student == null)
        //    {
        //        return NotFound("The student was not found");
        //    }

        //    _context.Students.Remove(student);
        //    _context.SaveChanges();
        //    return Ok(student);

        //}
    }
}
