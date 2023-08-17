using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;
using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Domain.Entities.Enrollments;

public class EnrollmentEntity : Auditable
{
    public long UserId { get; set; }
    public UserEntity User { get; set; }
    public long CourseId { get; set; }
    public CourseEntity Course { get; set; }
    public ICollection<ProgressEntity> Progresses { get; set; }
}
