using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService questionService;

    public QuestionController(IQuestionService questionService)
    {
        this.questionService = questionService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(QuestionCreationDTO dto)
    {
        var result = await this.questionService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(QuestionUpdateDTO dto)
    {
        var result = await this.questionService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.questionService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.questionService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.questionService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetChoicesOfQuestion")]
    public async ValueTask<IActionResult> RetrieveChoicesOfQuestionAsync(long questionId)
    {
        var result = await this.questionService.RetrieveChoicesOfQuestionAsync(questionId);

        return Ok(result);
    }
}
