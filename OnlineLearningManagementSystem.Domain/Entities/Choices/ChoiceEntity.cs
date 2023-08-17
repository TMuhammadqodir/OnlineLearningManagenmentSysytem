using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Questions;

namespace OnlineLearningManagementSystem.Domain.Entities.Choices;

public class ChoiceEntity : Auditable
{
    public long Text { get; set; }
    public bool IsCorrect { get; set; }
    public char Letter { get; set; }
    public long QuestionId { get; set; }
    public QuestionEntity Question { get; set; }
}
