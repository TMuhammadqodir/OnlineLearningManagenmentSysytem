using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;

namespace OnlineLearningManagementSystem.Domain.Entities.Lessons;

public class LessonResultDTO
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long CourseId { get; set; }  
    public ICollection<ProgressResultDTO> Progresses { get; set; }
}