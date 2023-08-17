using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Choices;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IChoiceService
{
    ValueTask<ChoiceResultDTO> AddAsync(ChoiceCreationDTO dto);
    ValueTask<ChoiceResultDTO> ModifyAsync(ChoiceUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ChoiceResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ChoiceResultDTO>> RetrieveAllAsync();
    ValueTask<ChoiceResultDTO> RetrieveCorrectChoiceOfQuestionAsync(long questionId);
}
