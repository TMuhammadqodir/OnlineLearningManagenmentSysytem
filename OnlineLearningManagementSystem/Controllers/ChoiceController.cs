using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Choices;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoiceController: ControllerBase
{
    private readonly IChoiceService choiceService;

    public ChoiceController(IChoiceService choiceService)
    {
        this.choiceService = choiceService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(ChoiceCreationDTO dto)
    {
        var result = await this.choiceService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(ChoiceUpdateDTO dto)
    {
        var result = await this.choiceService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.choiceService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.choiceService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.choiceService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetCorrectChoiceOfQuestion")]
    public async ValueTask<IActionResult> GetCorrectChoiceOfQuestion(long questionId)
    {
        var result = await this.choiceService.RetrieveCorrectChoiceOfQuestionAsync(questionId);

        return Ok(result);
    }
}
