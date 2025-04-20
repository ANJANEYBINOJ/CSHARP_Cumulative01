using Cumulative01.DALL;
using Microsoft.AspNetCore.Mvc;
using Cumulative01.Models;

namespace Cumulative01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherAPIController : ControllerBase
    {
        private readonly TeacherData _data;

        public TeacherAPIController(IConfiguration config)
        {
            _data = new TeacherData(config);
        }

        // READ - Get all teachers
        [HttpGet]
        public IActionResult GetAllTeachers() => Ok(_data.GetAllTeachers());

        // READ - Get one teacher by ID
        [HttpGet("{id}")]
        public IActionResult GetTeacher(int id)
        {
            var teacher = _data.GetTeacherById(id);
            return teacher == null ? NotFound("Teacher not found.") : Ok(teacher);
        }

    }
}
