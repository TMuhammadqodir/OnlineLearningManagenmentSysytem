using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;
using OnlineLearningManagementSystem.Domain.Entities.Users;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;
using System.Runtime.CompilerServices;

namespace OnlineLearningManagementSystem.Service.Services;

public class QuizzService : IQuizzService
{
    private readonly IRepository<QuizzEntity> repository;
    private readonly IRepository<CourseEntity> courseRepository;
    private readonly IRepository<UserEntity> userRepository;
    private readonly IMapper mapper;

    public QuizzService(IRepository<QuizzEntity> repository, IRepository<CourseEntity> courseRepository, IRepository<UserEntity> userRepository)
    {
        this.repository = repository;
        this.courseRepository = courseRepository;
        this.userRepository = userRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<QuizzResultDTO> AddAsync(QuizzCreationDTO dto)
    {
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));
        var existUser = await this.userRepository.GetAsync(u => u.Id.Equals(dto.UserId));

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        if (existUser is null)
            throw new NotFoundException($"This User not found Id = {dto.CourseId}");

        var entity = mapper.Map<QuizzEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizzResultDTO>(entity);
        return result;
    }

    public async ValueTask<QuizzResultDTO> ModifyAsync(QuizzUpdateDTO dto)
    {
        var existQuizz = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));
        var existUser = await this.userRepository.GetAsync(u => u.Id.Equals(dto.UserId));

        if (existQuizz is null)
            throw new NotFoundException($"This Quizz not found Id = {dto.Id}");

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        if (existUser is null)
            throw new NotFoundException($"This User not found Id = {dto.CourseId}");

        mapper.Map(dto, existQuizz);

        this.repository.Update(existQuizz);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuizzResultDTO>(existQuizz);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existQuizz = await repository.GetAsync(q => q.Id.Equals(id));

        if (existQuizz is null)
            throw new NotFoundException($"This Quizz not found Id = {id}");

        this.repository.Delete(existQuizz);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<QuizzResultDTO> RetrieveByIdAsync(long id)
    {
        var existQuizz = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Course", "User", "Questions" });

        if (existQuizz is null)
            throw new NotFoundException($"This Quizz not found Id = {id}");

        var result = mapper.Map<QuizzResultDTO>(existQuizz);
        return result;
    }

    public async ValueTask<IEnumerable<QuizzResultDTO>> RetrieveAllAsync()
    {
        var Quizzs = this.repository.GetAll(null, true, new string[] { "Course", "User", "Questions" });
        var result = mapper.Map<IEnumerable<QuizzResultDTO>>(Quizzs);
        return result;
    }

    public async ValueTask<IEnumerable<QuizzResultDTO>> RetrieveQuestionsOfQuizzAsync(long quizzId)
    {
        var quizzes = this.repository.GetAll(l => l.Id.Equals(quizzId), true, new string[] { "Questions" });
        var result = mapper.Map<IEnumerable<QuizzResultDTO>>(quizzes);
        return result;
    }
}
