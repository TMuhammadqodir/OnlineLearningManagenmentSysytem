using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;

namespace OnlineLearningManagementSystem.Domain.Entities.Lessons;

public class LessonEntity : Auditable
{
    public int Number { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long CourseId { get; set; }
    public CourseEntity Course { get; set; }
    public ICollection<ProgressEntity> Progresses { get; set; }
}
