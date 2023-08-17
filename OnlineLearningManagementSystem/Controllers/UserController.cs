using Microsoft.AspNetCore.Mvc;
using OnlineLearningManagementSystem.Domain.Entities.Users;
using OnlineLearningManagementSystem.Service.IServices;

namespace OnlineLearningManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("Post")]
    public async ValueTask<IActionResult> Post(UserCreationDTO dto)
    {
        var result = await this.userService.AddAsync(dto);

        return Ok(result);
    }

    [HttpPut("Put")]
    public async ValueTask<IActionResult> Put(UserUpdateDTO dto)
    {
        var result = await this.userService.ModifyAsync(dto);

        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await this.userService.RemoveAsync(id);

        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async ValueTask<IActionResult> GetById(long id)
    {
        var result = await this.userService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await this.userService.RetrieveAllAsync();

        return Ok(result);
    }

    [HttpGet("GetQuizzesOfUsers")]
    public async ValueTask<IActionResult> RetrieveQuizzesOfUsersAsync(long userId)
    {
        var result = await this.userService.RetrieveQuizzesOfUsersAsync(userId);

        return Ok(result);
    }
}
