using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IUserService
{
    ValueTask<UserResultDTO> AddAsync(UserCreationDTO dto);
    ValueTask<UserResultDTO> ModifyAsync(UserUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<UserResultDTO>> RetrieveAllAsync();
    ValueTask<IEnumerable<UserResultDTO>> RetrieveQuizzesOfUsersAsync(long userId);
}
