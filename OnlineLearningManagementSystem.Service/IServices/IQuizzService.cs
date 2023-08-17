using OnlineLearningManagementSystem.Domain.Entities.Quizzes;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IQuizzService
{
    ValueTask<QuizzResultDTO> AddAsync(QuizzCreationDTO dto);
    ValueTask<QuizzResultDTO> ModifyAsync(QuizzUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<QuizzResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<QuizzResultDTO>> RetrieveAllAsync();
    ValueTask<IEnumerable<QuizzResultDTO>> RetrieveQuestionsOfQuizzAsync(long quizzId);
}
