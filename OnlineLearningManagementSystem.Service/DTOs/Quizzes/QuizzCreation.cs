using OnlineLearningManagementSystem.Domain.Entities.Questions;

namespace OnlineLearningManagementSystem.Domain.Entities.Quizzes;

public class QuizzCreationDTO
{
    public string Title { get; set; }
    public long CourseId { get; set; }
    public long UserId { get; set; }
}
