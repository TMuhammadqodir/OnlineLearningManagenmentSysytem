using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Quizzes;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;

namespace OnlineLearningManagementSystem.Service.Services;

public class QuestionService : IQuestionService
{
    private readonly IRepository<QuestionEntity> repository;
    private readonly IRepository<QuizzEntity> quizzRepository;
    private readonly IMapper mapper;

    public QuestionService(IRepository<QuestionEntity> repository, IRepository<QuizzEntity> quizzRepository)
    {
        this.repository = repository;
        this.quizzRepository = quizzRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<QuestionResultDTO> AddAsync(QuestionCreationDTO dto)
    {
        var existQuizz = await this.quizzRepository.GetAsync(u => u.Id.Equals(dto.QuizzId));

        if (existQuizz is null)
            throw new NotFoundException($"This Quizz not found Id = {dto.QuizzId}");

        var entity = mapper.Map<QuestionEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuestionResultDTO>(entity);
        return result;
    }

    public async ValueTask<QuestionResultDTO> ModifyAsync(QuestionUpdateDTO dto)
    {
        var existQuestion = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));
        var existQuizz = await this.quizzRepository.GetAsync(u => u.Id.Equals(dto.QuizzId));

        if (existQuestion is null)
            throw new NotFoundException($"This Question not found Id = {dto.Id}");

        if (existQuizz is null)
            throw new NotFoundException($"This Quizz not found Id = {dto.QuizzId}");

        mapper.Map(dto, existQuestion);

        this.repository.Update(existQuestion);
        await this.repository.SaveAsync();

        var result = mapper.Map<QuestionResultDTO>(existQuestion);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existQuestion = await repository.GetAsync(c => c.Id.Equals(id));

        if (existQuestion is null)
            throw new NotFoundException($"This Question not found Id = {id}");

        this.repository.Delete(existQuestion);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<QuestionResultDTO> RetrieveByIdAsync(long id)
    {
        var existQuestion = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Quizz", "Choices" });

        if (existQuestion is null)
            throw new NotFoundException($"This Question not found Id = {id}");

        var result = mapper.Map<QuestionResultDTO>(existQuestion);
        return result;
    }

    public async ValueTask<IEnumerable<QuestionResultDTO>> RetrieveAllAsync()
    {
        var Questions = this.repository.GetAll(null, true, new string[] { "Quizz", "Choices" });
        var result = mapper.Map<IEnumerable<QuestionResultDTO>>(Questions);
        return result;
    }

    public async ValueTask<IEnumerable<QuestionResultDTO>> RetrieveChoicesOfQuestionAsync(long questionId)
    {
        var questions = this.repository.GetAll(l => l.Id.Equals(questionId), true, new string[] { "Choices" });
        var result = mapper.Map<IEnumerable<QuestionResultDTO>>(questions);
        return result;
    }
}
