using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgressController : ControllerBase
{
    private readonly IProgressService progressService;

    public ProgressController(IProgressService progressService)
    {
        this.progressService = progressService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(ProgressCreationDTO dto)
    {
        var result = await this.progressService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(ProgressUpdateDTO dto)
    {
        var result = await this.progressService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.progressService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.progressService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.progressService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetIsComplectedLesson")]
    public async ValueTask<IActionResult> IsComplectedLessonAsync(long lessonId)
    {
        var result = await this.progressService.IsComplectedLessonAsync(lessonId);

        return Ok(result);
    }
}
