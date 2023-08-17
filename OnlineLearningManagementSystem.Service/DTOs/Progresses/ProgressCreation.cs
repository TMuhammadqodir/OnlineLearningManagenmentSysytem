namespace OnlineLearningManagementSystem.Domain.Entities.Progresses;

public class ProgressCreationDTO
{
    public bool IsComplected { get; set; }
    public long LessonId { get; set; }
    public long EnrollmentId { get; set; }
}
