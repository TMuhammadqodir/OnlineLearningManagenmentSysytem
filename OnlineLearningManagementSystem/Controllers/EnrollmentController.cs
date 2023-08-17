using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        this.enrollmentService = enrollmentService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(EnrollmentCreationDTO dto)
    {
        var result = await this.enrollmentService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(EnrollmentUpdateDTO dto)
    {
        var result = await this.enrollmentService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.enrollmentService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.enrollmentService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.enrollmentService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetCountUsersOfCourse")]
    public async ValueTask<IActionResult> CountUsersOfCourse(long id)
    {
        var result = await this.enrollmentService.CountUsersOfCourseAsync(id);

        return Ok(result);
    }

    [HttpPatch("GetCountCourseOfUser")]
    public async ValueTask<IActionResult> CountCourseOfUser(long id)
    {
        var result = await this.enrollmentService.CountUsersOfCourseAsync(id);

        return Ok(result);
    }
}
