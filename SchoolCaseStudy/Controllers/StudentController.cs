using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var students = _context.Students.ToList();
            return students;

        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student =_context.Students.FirstOrDefault(a=>a.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }


    }
}
