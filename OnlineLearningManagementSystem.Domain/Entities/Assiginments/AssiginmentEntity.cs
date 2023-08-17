using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;

namespace OnlineLearningManagementSystem.Domain.Entities.Assiginments;

public class AssiginmentEntity : Auditable
{
    public int Number { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
    public CourseEntity Course { get; set; }
}
