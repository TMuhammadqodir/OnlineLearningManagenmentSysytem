namespace OnlineLearningManagementSystem.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; }
}
