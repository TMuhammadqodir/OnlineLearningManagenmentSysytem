using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;

namespace OnlineLearningManagementSystem.Domain.Entities.Users;

public class UserEntity : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public ICollection<QuizzEntity> Quizzes { get; set; }
    public ICollection<EnrollmentEntity> Enrollments { get; set; }
}
