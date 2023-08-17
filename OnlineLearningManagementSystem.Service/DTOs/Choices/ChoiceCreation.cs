namespace OnlineLearningManagementSystem.Domain.Entities.Choices;

public class ChoiceCreationDTO
{
    public long Text { get; set; }
    public bool IsCorrect { get; set; }
    public char Letter { get; set; }
    public long QuestionId { get; set; }
}
