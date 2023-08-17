using OnlineLearningManagementSystem.Domain.Entities.Courses;

namespace OnlineLearningManagementSystem.Service.IServices;

public interface ICourseService
{
    ValueTask<CourseResultDTO> AddAsync(CourseCreationDTO dto);
    ValueTask<CourseResultDTO> ModifyAsync(CourseUpdateDTO dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<CourseResultDTO> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CourseResultDTO>> RetrieveAllAsync();
    ValueTask<IEnumerable<CourseResultDTO>> RetrieveLessonsOfCourseAsync(long courseId);
    ValueTask<IEnumerable<CourseResultDTO>> RetrieveQuizzesOfCourseAsync(long courseId);
    ValueTask<IEnumerable<CourseResultDTO>> RetrieveAssiginmentsOfCourseAsync(long courseId);
}
