using OnlineLearningManagementSystem.Domain.Entities.Questions;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IQuestionService
{
    ValueTask<QuestionResultDTO> AddAsync(QuestionCreationDTO dto);
    ValueTask<QuestionResultDTO> ModifyAsync(QuestionUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<QuestionResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<QuestionResultDTO>> RetrieveAllAsync();
    ValueTask<IEnumerable<QuestionResultDTO>> RetrieveChoicesOfQuestionAsync(long questionId);
}
