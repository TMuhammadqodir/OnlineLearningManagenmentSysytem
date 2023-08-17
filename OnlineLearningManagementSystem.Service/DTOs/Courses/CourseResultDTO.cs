using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;

namespace OnlineLearningManagementSystem.Domain.Entities.Courses;

public class CourseResultDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<LessonResultDTO> Lessons { get; set; }
    public ICollection<AssiginmentResultDTO> Assiginments { get; set; }
    public ICollection<QuizzResultDTO> Quizzes { get; set; }
    public ICollection<EnrollmentResultDTO> Enrollments { get; set; }
}