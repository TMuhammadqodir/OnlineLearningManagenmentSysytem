using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;

namespace OnlineLearningManagementSystem.Domain.Entities.Courses;

public class CourseEntity : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<LessonEntity> Lessons { get; set; }
    public ICollection<AssiginmentEntity> Assiginments { get; set; }
    public ICollection<QuizzEntity> Quizzes { get; set; }
    public ICollection<EnrollmentEntity> Enrollments { get; set; }
}
