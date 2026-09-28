using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Mapping;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.Interfaces;

namespace SchoolCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _repo.GetAll();
            var dto =_mapper.Map<List<GetStudentDTO>>(students);
            return Ok(dto);
        }



        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
           var student=_repo.GetById(id);
            if (student == null) { 
            return NotFound();
            }
            var dto=_mapper.Map<GetStudentDTO>(student);
            return Ok(dto);

        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO studentdto) {

            if (studentdto == null)
            {
                return BadRequest();
            }
            var dto = _mapper.Map<Student>(studentdto);
            _repo.Add(dto);
            _repo.Save();
            return Created();
           
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, CreateStudentDTO studto)
        {
            if (studto == null) { 
            return BadRequest();
            }

            var student = _repo.GetById(id);
            if (student == null) {
                return NotFound();
            }
            _mapper.Map(studto,student);
            _repo.Update(student);
            _repo.Save();
            return Ok(student);
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _repo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            _repo.Delete(id);
            _repo.Save();

            return NoContent();

        }

        [HttpGet("Get-By-ClassRoomId")]
        public IActionResult GetStudentByClassRoomId(int Classroomid) { 
           var stu= _repo.SearchByClassRoomId(Classroomid);
            if(stu == null)
            {
                return NotFound();
            }
           
             var dto =_mapper.Map<List<GetStudentDTO>>(stu);
            return Ok(dto);
        
        }

        ////1
        ////2
        //[HttpGet("filter")]
        //public IActionResult Getstudentsfilter([FromQuery] int classroomid, [FromQuery] int gradelevel)
        //{
        //    var students = _context.Students
        //        .Include(x=>x.ClassRoom)
        //        .Where(x=>x.ClassRoomId == classroomid&& x.ClassRoom.GradeLevel== gradelevel);
        //    var studentDTOs = _mapper.Map<List<GetStudentDTO>>(students);

        //    return Ok(studentDTOs);
        //}

        ////2
        //[HttpGet("first")]
        //public IActionResult GetFirst([FromQuery]int classroomid)
        //{
        //    var students = _context.Students.Include(x => x.ClassRoom)
        //        .First(x => x.ClassRoomId == classroomid);
        //    var studentDTOs = _mapper.Map<GetStudentDTO>(students);

        //    return Ok(studentDTOs);
        //}
        ////3
        //[HttpGet("First-Or-Default")]
        //public IActionResult GetFirstorDefault([FromQuery] int classroomid)
        //{
        //    var students = _context.Students.Include(x => x.ClassRoom)
        //        .FirstOrDefault(x => x.ClassRoomId == classroomid);
        //    var studentDTOs = _mapper.Map<GetStudentDTO>(students);

        //    return Ok(studentDTOs);
        //}
        ////4 
        //public IActionResult Getsingle([FromQuery] string email)
        //{
        //    var students = _context.Students.Include(x => x.ClassRoom)
        //        .Single(x => x.Email == email);
        //    var studentDTOs = _mapper.Map<GetStudentDTO>(students);

        //    return Ok(studentDTOs);
        //}

        ////5
        //public IActionResult GetsingleOrDefault([FromQuery] string email)
        //{
        //    var students = _context.Students.Include(x => x.ClassRoom)
        //        .SingleOrDefault(x => x.Email == email);
        //    var studentDTOs = _mapper.Map<GetStudentDTO>(students);

        //    return Ok(studentDTOs);
        //}


        ////12
        //[HttpGet("{id}")]
        //public IActionResult GetStudentInClassroom(int id)
        //{
        //    var students = _context.Students
        //        .Include(x => x.ClassRoom)
        //        .Where(a => a.ClassRoomId == id)
        //        .Select( s=>new 
        //        {
        //          Id= s.Id,
        //           FullName= s.FirstName+' ' + s.LastName

        //        });


        //   // var studentDTOs = _mapper.Map<List<GetStudentDTO>>(students);

        //    return Ok(students);

        //}
        ////13
        //[HttpGet("{Classroomid}")]
        //public IActionResult GetStudentAsObject(int id)
        //{
        //    var students = _context.Students
        //        .Include (x => x.ClassRoom)
        //        .Where(a => a.ClassRoomId == id)
        //        .Select(s => new
        //        {
        //            Id = s.Id,
        //            FullName = s.FirstName + ' ' + s.LastName,
        //            Email= s.Email

        //        }).ToList();


        //    // var studentDTOs = _mapper.Map<List<GetStudentDTO>>(students);

        //    return Ok(students);

        //}
        

    }
}
