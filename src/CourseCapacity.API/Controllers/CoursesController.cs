
using CourseCapacity.API.Data;
using CourseCapacity.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseCapacity.API.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /courses
    // Lấy danh sách tất cả lớp học phần
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseSection>>> GetCourses()
    {
        var courses = await _context.CourseSections
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToListAsync();

        return Ok(courses);
    }

    // GET: /courses/{id}
    // Lấy thông tin chi tiết một lớp học phần
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseSection>> GetCourse(int id)
    {
        var course = await _context.CourseSections
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null)
        {
            return NotFound(new
            {
                message = $"Không tìm thấy lớp học phần có ID = {id}"
            });
        }

        return Ok(course);
    }
}
