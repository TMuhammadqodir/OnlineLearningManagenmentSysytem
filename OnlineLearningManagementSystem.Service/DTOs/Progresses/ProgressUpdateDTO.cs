namespace OnlineLearningManagementSystem.Domain.Entities.Progresses;

public class ProgressUpdateDTO
{
    public long Id { get; set; }
    public bool IsComplected { get; set; }
    public long LessonId { get; set; }
    public long EnrollmentId { get; set; }
}
