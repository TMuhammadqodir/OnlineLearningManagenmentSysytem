namespace OnlineLearningManagementSystem.Domain.Entities.Assiginments;

public class AssiginmentUpdateDTO
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}
