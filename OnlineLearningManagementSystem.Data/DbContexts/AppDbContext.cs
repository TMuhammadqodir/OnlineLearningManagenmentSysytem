using Microsoft.EntityFrameworkCore;
using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Choices;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;
using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<AssiginmentEntity> Assiginments { get; set; }
    public DbSet<ChoiceEntity> Choices { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<EnrollmentEntity> Enrollments { get; set; }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<ProgressEntity> Progresses { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<QuizzEntity> Quizzes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}
