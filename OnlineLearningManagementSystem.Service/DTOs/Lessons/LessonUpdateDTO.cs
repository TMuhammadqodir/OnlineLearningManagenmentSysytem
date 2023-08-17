namespace OnlineLearningManagementSystem.Domain.Entities.Lessons;

public class LessonUpdateDTO
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long CourseId { get; set; }
}
