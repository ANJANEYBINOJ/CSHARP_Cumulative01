using Cumulative01.DALL;
using Cumulative01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative01.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly TeacherData _data;

        public TeacherPageController(IConfiguration config)
        {
            _data = new TeacherData(config);
        }

        // READ: List all teachers
        public IActionResult List()
        {
            return View(_data.GetAllTeachers());
        }

        // READ: Show one teacher
        public IActionResult Show(int id)
        {
            var teacher = _data.GetTeacherById(id);
            return teacher == null ? NotFound("Teacher not found.") : View(teacher);
        }

    }
}
