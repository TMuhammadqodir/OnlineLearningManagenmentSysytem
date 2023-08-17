namespace OnlineLearningManagementSystem.Domain.Entities.Quizzes;

public class QuizzUpdateDTO
{
    public long Id { get; set; }
    public string Title { get; set; }
    public long CourseId { get; set; }
    public long UserId { get; set; }
}
