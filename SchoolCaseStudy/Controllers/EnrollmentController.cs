using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.DTOs;
using SchoolCaseStudy.Mapping;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
            var conf = new MapperConfiguration(x => {
                x.AddProfile<EnrollmentProfile>();
            });
            _mapper = conf.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllEnrollments()
        {
            var enrollments = _context.Enrollments.ToList();

            var enrollmentDTOs =_mapper.Map<List<GetEnrollmentDTO>>(enrollments);

            return Ok(enrollmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound("The Enrollment was not found");
            }

            var enrollmentDTO =_mapper.Map<GetEnrollmentDTO>(enrollment);

            return Ok(enrollmentDTO);
        }

        
        [HttpPost]
        public IActionResult CreateEnrollment(CreateEnrollmentDTO enrollmentDTO)
        {
            if (enrollmentDTO == null)
            {
                return BadRequest();
            }

            var studentExists = _context.Students.Any(s => s.Id == enrollmentDTO.StudentId);

            if (!studentExists)
            {
                return BadRequest("The Student does not exist");
            }

            var subjectExists = _context.Subjects.Any(s => s.Id == enrollmentDTO.SubjectId);

            if (!subjectExists)
            {
                return BadRequest("The Subject does not exist");
            }

            var enrollment =_mapper.Map<Enrollment>(enrollmentDTO);

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id,CreateEnrollmentDTO enrollmentDTO)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound("The Enrollment was not found");
            }

            var studentExists = _context.Students.Any(s => s.Id == enrollmentDTO.StudentId);

            if (!studentExists)
            {
                return BadRequest("The Student does not exist");
            }

            var subjectExists = _context.Subjects.Any(s => s.Id == enrollmentDTO.SubjectId);

            if (!subjectExists)
            {
                return BadRequest("The Subject does not exist");
            }

            _mapper.Map(enrollmentDTO, enrollment);

            _context.SaveChanges(enrollment);

            
               

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound("The Enrollment was not found");
            }

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();

            return Ok();
        }
    }
}
