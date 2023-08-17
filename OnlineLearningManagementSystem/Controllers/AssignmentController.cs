using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService assignmentService;

    public AssignmentController(IAssignmentService assignmentService)
    {
        this.assignmentService = assignmentService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(AssiginmentCreationDTO dto)
    {
        var result = await this.assignmentService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(AssiginmentUpdateDTO dto)
    {
        var result = await this.assignmentService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.assignmentService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.assignmentService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.assignmentService.RetrieveAllAsync();

        return Ok(result);
    }
}
