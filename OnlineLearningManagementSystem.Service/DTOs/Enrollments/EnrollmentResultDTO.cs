using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;
using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Domain.Entities.Enrollments;

public class EnrollmentResultDTO
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long CourseId { get; set; }
    public ICollection<ProgressEntity> Progresses { get; set; }
}