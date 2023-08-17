
using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;

namespace OnlineLearningManagementSystem.Domain.Entities.Progresses;

public class ProgressEntity : Auditable
{
    public bool IsComplected { get; set; }
    public long LessonId { get; set; }
    public LessonEntity Lesson { get; set; }
    public long EnrollmentId { get; set; }
    public EnrollmentEntity Enrollment { get; set; }
}
