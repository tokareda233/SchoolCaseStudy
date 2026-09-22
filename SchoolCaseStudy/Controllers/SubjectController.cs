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
    public class SubjectController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SubjectController(AppDbContext context)
        {
            _context = context;

            var conf = new MapperConfiguration(x =>
            {
                x.AddProfile<SubjectProfile>();
            });

            _mapper = conf.CreateMapper();
        }


        public IActionResult GetAllSubjects()
        {
            var subjects = _context.Subjects.ToList();

            var subjectDTOs =_mapper.Map<List<GetsubjectDTO>>(subjects);

            return Ok(subjectDTOs);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound("The Subject was not found");
            }

            var subjectDTO = _mapper.Map<GetsubjectDTO>(subject);

            return Ok(subjectDTO);
        }

        
        [HttpPost]
        public IActionResult CreateSubject(CreateSubjectDTO subjectDTO)
        {
            if (subjectDTO == null)
            {
                return BadRequest();
            }

            var teacherExists = _context.Teachers.Any(t => t.Id == subjectDTO.TeacherId);

            if (!teacherExists)
            {
                return BadRequest("The Teacher does not exist");
            }

            var subject =_mapper.Map<Subject>(subjectDTO);

            _context.Subjects.Add(subject);
            _context.SaveChanges();


            return Ok();
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id,CreateSubjectDTO subjectDTO)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound("The Subject was not found");
            }

            var teacherExists = _context.Teachers.Any(t => t.Id == subjectDTO.TeacherId);

            if (!teacherExists)
            {
                return BadRequest("The Teacher does not exist");
            }

            _mapper.Map(subjectDTO, subject);

            _context.SaveChanges();

            

            return Ok(subject);
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound("The Subject was not found");
            }

            _context.Subjects.Remove(subject);
            _context.SaveChanges();

            return Ok();
        }
    }
}
