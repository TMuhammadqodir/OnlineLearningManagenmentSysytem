using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzController : ControllerBase
{
    private readonly IQuizzService quizzService;

    public QuizzController(IQuizzService quizzService)
    {
        this.quizzService = quizzService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(QuizzCreationDTO dto)
    {
        var result = await this.quizzService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(QuizzUpdateDTO dto)
    {
        var result = await this.quizzService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.quizzService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.quizzService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.quizzService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetQuestionsOfQuizz")]
    public async ValueTask<IActionResult> RetrieveQuestionsOfQuizzAsync(long quizzId)
    {
        var result = await this.quizzService.RetrieveQuestionsOfQuizzAsync(quizzId);

        return Ok(result);
    }
}
