using OnlineLearningManagementSystem.Domain.Entities.Questions;

namespace OnlineLearningManagementSystem.Domain.Entities.Choices;

public class ChoiceResultDTO
{
    public long Id { get; set; }
    public long Text { get; set; }
    public bool IsCorrect { get; set; }
    public char Letter { get; set; }
    public long QuestionId { get; set; }
}