using AutoMapper;
using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Choices;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;
using OnlineLearningManagementSystem.Domain.Entities.Users;

namespace OnlineLearningManagementSystem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    { 
        CreateMap<UserEntity, UserCreationDTO>().ReverseMap();
        CreateMap<UserEntity, UserUpdateDTO>().ReverseMap();
        CreateMap<UserEntity, UserResultDTO>().ReverseMap();

        CreateMap<QuizzEntity, QuizzCreationDTO>().ReverseMap();
        CreateMap<QuizzEntity, QuizzUpdateDTO>().ReverseMap();
        CreateMap<QuizzEntity, QuizzResultDTO>().ReverseMap();

        CreateMap<QuestionEntity, QuestionCreationDTO>().ReverseMap();
        CreateMap<QuestionEntity, QuestionUpdateDTO>().ReverseMap();
        CreateMap<QuestionEntity, QuestionResultDTO>().ReverseMap();

        CreateMap<ProgressEntity, ProgressCreationDTO>().ReverseMap();
        CreateMap<ProgressEntity, ProgressUpdateDTO>().ReverseMap();
        CreateMap<ProgressEntity, ProgressResultDTO>().ReverseMap();

        CreateMap<LessonEntity, LessonCreationDTO>().ReverseMap();
        CreateMap<LessonEntity, LessonUpdateDTO>().ReverseMap();
        CreateMap<LessonEntity, LessonResultDTO>().ReverseMap();

        CreateMap<EnrollmentEntity, EnrollmentCreationDTO>().ReverseMap();
        CreateMap<EnrollmentEntity, EnrollmentUpdateDTO>().ReverseMap();
        CreateMap<EnrollmentEntity, EnrollmentResultDTO>().ReverseMap();

        CreateMap<CourseEntity, CourseCreationDTO>().ReverseMap();
        CreateMap<CourseEntity, CourseUpdateDTO>().ReverseMap();
        CreateMap<CourseEntity, CourseResultDTO>().ReverseMap();

        CreateMap<ChoiceEntity, ChoiceCreationDTO>().ReverseMap();
        CreateMap<ChoiceEntity, ChoiceUpdateDTO>().ReverseMap();
        CreateMap<ChoiceEntity, ChoiceResultDTO>().ReverseMap();

        CreateMap<AssiginmentEntity, AssiginmentCreationDTO>().ReverseMap();
        CreateMap<AssiginmentEntity, AssiginmentCreationDTO>().ReverseMap();
        CreateMap<AssiginmentEntity, AssiginmentResultDTO>().ReverseMap();
    }
}
