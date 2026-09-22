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
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TeacherController(AppDbContext context)
        {
            _context = context;
            var conf = new MapperConfiguration(x =>
            {
                x.AddProfile<TeacherProfile>();
            });
            _mapper = conf.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll() { 
        
            var teach=_context.Teachers.Include(a=>a.Department).ToList();
            if (teach == null||teach.Count==0) {
                return NotFound();
            }

            var dtos = _mapper.Map<List<TeacherGetDTO>>(teach);

            //foreach (var item in teach) {
            //    var d = new TeacherGetDTO()
            //    {
            //        Id = item.Id,
            //       FullName=item.FirstName+" "+item.LastName,
            //        Email = item.Email,
            //        PhoneNumber = item.PhoneNumber,
            //        Salary = item.Salary,
            //        DepartmentId = item.DepartmentId,
            //        DepartmentName=item.Department.Name
            //    };
            //    dtos.Add(d);
            //}

            return Ok(dtos);
        }

        [HttpGet("{id}")]

        public IActionResult GetTeacher(int id)
        {
            var tech=_context.Teachers.FirstOrDefault(x=>x.Id==id);
            if(tech == null)
            {
                return NotFound();
            }
            var dto=_mapper.Map<TeacherGetDTO>(tech);
            return Ok(dto);
        }


        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDTO dto) {
            if (dto == null) { 
               return BadRequest("Enter Data");
            }

            var tech=_mapper.Map<Teacher>(dto);
            //string name=dto.FullName;
            //string Fname = "";
            //string Lname = "";
            //int j = 0;
            //foreach (char c in name) { 
            //  Fname+= c;
            //    j++;
            //    if(c==' ')
            //    {
            //        break;
            //    }

            //}
            //for (int i = j; i < name.Length; i++) { 
            //        Lname+= name[i];
            
            //}
            //var tech = new Teacher()
            //{
            //    FirstName = Fname,
            //    LastName = Lname,
            //    Email = dto.Email,
            //    PhoneNumber = dto.PhoneNumber,
            //    Salary = dto.Salary,
            //    DepartmentId = dto.DepartmentId,

            //};
          
            _context.Teachers.Add(tech);
            _context.SaveChanges();
            return Created();
          
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id,CreateTeacherDTO dto)
        {
            var tech=_context.Teachers.FirstOrDefault(x=>x.Id == id);
            if (tech == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, tech);
            _context.SaveChanges();
            return Ok(tech);

        }

        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(a => a.Id == id);

            if (teacher == null)
            {
                return NotFound("The student was not found");
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return Ok(teacher);

        }
    }
}
