using OnlineLearningManagementSystem.Domain.Entities.Courses;

namespace OnlineLearningManagementSystem.Domain.Entities.Assiginments;

public class AssiginmentResultDTO
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}