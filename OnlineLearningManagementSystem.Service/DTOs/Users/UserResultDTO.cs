using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;

namespace OnlineLearningManagementSystem.Domain.Entities.Users;

public class UserResultDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public ICollection<QuizzResultDTO> Quizzes { get; set; }
    public ICollection<EnrollmentResultDTO> Enrollments { get; set; }
}