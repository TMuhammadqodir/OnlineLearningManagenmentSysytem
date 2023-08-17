using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface ILessonService
{
    ValueTask<LessonResultDTO> AddAsync(LessonCreationDTO dto);
    ValueTask<LessonResultDTO> ModifyAsync(LessonUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<LessonResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<LessonResultDTO>> RetrieveAllAsync();
    ValueTask<IEnumerable<LessonResultDTO>> RetrieveProgressesOfLessonAsync(long id);
}
