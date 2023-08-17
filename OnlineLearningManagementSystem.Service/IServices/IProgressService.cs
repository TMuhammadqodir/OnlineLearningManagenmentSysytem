using OnlineLearningManagementSystem.Domain.Entities.Progresses;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IProgressService
{
    ValueTask<ProgressResultDTO> AddAsync(ProgressCreationDTO dto);
    ValueTask<ProgressResultDTO> ModifyAsync(ProgressUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ProgressResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ProgressResultDTO>> RetrieveAllAsync();
    ValueTask<bool> IsComplectedLessonAsync(long lessonId);
}
