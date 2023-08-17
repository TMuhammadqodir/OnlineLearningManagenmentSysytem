using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService courseService;

    public CourseController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(CourseCreationDTO dto)
    {
        var result = await this.courseService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(CourseUpdateDTO dto)
    {
        var result = await this.courseService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.courseService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.courseService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.courseService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetLessonsOfCourse")]
    public async ValueTask<IActionResult> GetLessonsOfCourse(long courseId)
    {
        var result = await this.courseService.RetrieveLessonsOfCourseAsync(courseId);

        return Ok(result);
    }

    [HttpGet("GetQuizzesOfCourse")]
    public async ValueTask<IActionResult> GetQuizzesOfCourse(long courseId)
    {
        var result = await this.courseService.RetrieveQuizzesOfCourseAsync(courseId);

        return Ok(result);
    }

    [HttpGet("GetAssiginmentsOfCourse")]
    public async ValueTask<IActionResult> GetAssiginmentsOfCourse(long courseId)
    {
        var result = await this.courseService.RetrieveAssiginmentsOfCourseAsync(courseId);

        return Ok(result);
    }
}
