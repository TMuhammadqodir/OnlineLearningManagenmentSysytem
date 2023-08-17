using OnlineLearningManagementSystem.Domain.Entities.Assiginments;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IAssignmentService
{
    ValueTask<AssiginmentResultDTO> AddAsync(AssiginmentCreationDTO dto);
    ValueTask<AssiginmentResultDTO> ModifyAsync(AssiginmentUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<AssiginmentResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<AssiginmentResultDTO>> RetrieveAllAsync();
}
