using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface IEnrollmentService
{
    ValueTask<EnrollmentResultDTO> AddAsync(EnrollmentCreationDTO dto);
    ValueTask<EnrollmentResultDTO> ModifyAsync(EnrollmentUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<EnrollmentResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<EnrollmentResultDTO>> RetrieveAllAsync();
    ValueTask<int> CountUsersOfCourseAsync(long id);
    ValueTask<int> CountCourseOfUserAsync(long id);
}
