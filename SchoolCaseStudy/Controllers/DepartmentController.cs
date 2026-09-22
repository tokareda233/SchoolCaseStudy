using System.Security.Cryptography.Xml;
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
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
            var conf = new MapperConfiguration(x=>{
                x.AddProfile<DepartmentProfile>();
            });
            _mapper = conf.CreateMapper();
        }

        [HttpGet]
        public IActionResult Get() { 
        
          var Deps=_context.Departments.ToList();
            if (Deps == null || Deps.Count == 0) { 
            return NotFound("There are no Departments");
            }
            
            var dtos= _mapper.Map<List<GetDepDto>>(Deps);

            //foreach (var dep in Deps) {

            //    var dto = new GetDepDto()
            //    {
            //        Id = dep.Id,
            //        Name = dep.Name,
            //        Description = dep.Description,

            //    };
            //    dtos.Add(dto);
            //}
           
        return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllDepartment(int id) { 
           var dep = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (dep == null) { 
            return NotFound();
            }

            var dto=_mapper.Map<GetDepDto>(dep);
            //dto.Id = dep.Id;
            //dto.Name = dep.Name;
            //dto.Description = dep.Description;

            return Ok(dto);
        
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepDto dto) {

            if (dto == null) {
                return BadRequest("The Object is Null!!!!");
            }
            var dep=_mapper.Map<Department>(dto);
            //var dep = new Department()
            //{
            //    Name = dto.Name,
            //    Description = dto.Description,
            //};
            _context.Departments.Add(dep);
            _context.SaveChanges();
            return Created();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateDepartment(int id, CreateDepDto dto) { 
        var Dep=_context.Departments.FirstOrDefault(x=>x.Id == id);
            if (Dep == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, Dep);

            //Dep.Name = dto.Name;
            //Dep.Description = dto.Description;
           // _context.Departments.Update(Dep);
            _context.SaveChanges();
            return Ok();

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var dep = _context.Departments
                .FirstOrDefault(a => a.Id == id);

            if (dep == null)
            {
                return NotFound("The student was not found");
            }

            _context.Departments.Remove(dep);
            _context.SaveChanges();
            return Ok(dep);

        }
    }
}
