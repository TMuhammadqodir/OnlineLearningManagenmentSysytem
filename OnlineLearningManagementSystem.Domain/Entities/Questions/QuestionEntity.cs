﻿using OnlineLearningManagementSystem.Domain.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Choices;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;

namespace OnlineLearningManagementSystem.Domain.Entities.Questions;

public class QuestionEntity : Auditable
{
    public string Text { get; set; }
    public long QuizzId { get; set; }
    public QuizzEntity Quizz { get; set; }
    public ICollection<ChoiceEntity> Choices { get; set; }
}
