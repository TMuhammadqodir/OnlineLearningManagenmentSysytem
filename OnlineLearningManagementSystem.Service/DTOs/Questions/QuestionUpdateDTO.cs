namespace OnlineLearningManagementSystem.Domain.Entities.Questions;

public class QuestionUpdateDTO
{
    public long Id { get; set; }
    public string Text { get; set; }
    public long QuizzId { get; set; }
}
