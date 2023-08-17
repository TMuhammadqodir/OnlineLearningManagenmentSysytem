namespace OnlineLearningManagementSystem.Domain.Entities.Choices;

public class ChoiceUpdateDTO
{
    public long Id { get; set; }
    public long Text { get; set; }
    public bool IsCorrect { get; set; }
    public char Letter { get; set; }
    public long QuestionId { get; set; }
}
