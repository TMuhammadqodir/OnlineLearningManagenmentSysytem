using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Domain.Entities.Quizzes;

public class QuizzEntity : Auditable
{
    public string Title { get; set; }
    public long CourseId { get; set; }
    public CourseEntity Course { get; set; }
    public long UserId { get; set; }
    public UserEntity User { get; set; }
    public ICollection<QuestionEntity> Questions { get; set;}
}
