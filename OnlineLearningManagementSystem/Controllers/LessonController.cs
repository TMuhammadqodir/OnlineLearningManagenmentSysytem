using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly ILessonService lessonService;

    public LessonController(ILessonService lessonService)
    {
        this.lessonService = lessonService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(LessonCreationDTO dto)
    {
        var result = await this.lessonService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(LessonUpdateDTO dto)
    {
        var result = await this.lessonService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.lessonService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.lessonService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.lessonService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetProgressesOfLesson")]
    public async ValueTask<IActionResult> RetrieveProgressesOfLessonAsync(long id)
    {
        var result = await this.lessonService.RetrieveProgressesOfLessonAsync(id);

        return Ok(result);
    }
}
