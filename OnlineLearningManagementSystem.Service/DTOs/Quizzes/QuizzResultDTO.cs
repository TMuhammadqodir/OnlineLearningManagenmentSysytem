using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Domain.Entities.Quizzes;

public class QuizzResultDTO
{
    public long Id { get; set; }
    public string Title { get; set; }
    public long CourseId { get; set; }
    public long UserId { get; set; }
    public ICollection<QuestionEntity> Questions { get; set; }
}