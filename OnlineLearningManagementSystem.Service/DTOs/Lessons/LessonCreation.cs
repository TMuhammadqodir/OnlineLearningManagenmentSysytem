﻿namespace OnlineLearningManagementSystem.Domain.Entities.Lessons;

public class LessonCreationDTO
{
    public int Number { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long CourseId { get; set; }
}
