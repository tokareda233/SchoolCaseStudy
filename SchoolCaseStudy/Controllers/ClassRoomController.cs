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
    public class ClassRoomController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassRoomController(AppDbContext context)
        {
            _context = context;
            var conf = new MapperConfiguration(x =>
            {
                x.AddProfile<ClassRoomProfile>();
            });
            _mapper = conf.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllClassRooms()
        {
            var classRooms = _context.ClassRooms.ToList();

            var classRoomDTOs = _mapper.Map<List<GetClassRoomDTO>>(classRooms);


            return Ok(classRoomDTOs);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetClassRoom(int id)
        {
            var classRoom = _context.ClassRooms.FirstOrDefault(c => c.Id == id);

            if (classRoom == null)
            {
                return NotFound("The Classroom was not found");
            }

            var classRoomDTO = _mapper.Map<GetClassRoomDTO>(classRoom);


            return Ok(classRoomDTO);
        }

      
        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassRoomDTO classRoomDTO)
        {
            if (classRoomDTO == null)
            {
                return BadRequest();
            }

            var classRoom =_mapper.Map<ClassRoom>(classRoomDTO);

            _context.ClassRooms.Add(classRoom);
            _context.SaveChanges();

            return Ok();
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom( int id, CreateClassRoomDTO classRoomDTO)
        {
            var classRoom = _context.ClassRooms.FirstOrDefault(c => c.Id == id);

            if (classRoom == null)
            {
                return NotFound("The Classroom was not found");
            }

            _mapper.Map(classRoomDTO, classRoom);

            _context.SaveChanges();

            return Ok();
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            var classRoom = _context.ClassRooms
                .FirstOrDefault(c => c.Id == id);

            if (classRoom == null)
            {
                return NotFound("The Classroom was not found");
            }

            _context.ClassRooms.Remove(classRoom);
            _context.SaveChanges();

            return Ok(classRoom);
        }

    }
}
