
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;

namespace OnlineLearningManagementSystem.Domain.Entities.Progresses;

public class ProgressResultDTO
{
    public long Id { get; set; }
    public bool IsComplected { get; set; }
    public long UserId { get; set; }
    public long EnrollmentId { get; set; }
}