using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Choices;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;

namespace OnlineLearningManagementSystem.Service.Services;

public class ChoiceService : IChoiceService
{
    private readonly IRepository<ChoiceEntity> repository;
    private readonly IRepository<QuestionEntity> questionRepository;
    private readonly IMapper mapper;

    public ChoiceService(IRepository<ChoiceEntity> repository, IRepository<QuestionEntity> questionRepository)
    {
        this.repository = repository;
        this.questionRepository = questionRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<ChoiceResultDTO> AddAsync(ChoiceCreationDTO dto)
    {
        var existQuestion = await this.questionRepository.GetAsync(u => u.Id.Equals(dto.QuestionId));

        if (existQuestion is null)
            throw new NotFoundException($"This Question not found Id = {dto.QuestionId}");

        var entity = mapper.Map<ChoiceEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<ChoiceResultDTO>(entity);
        return result;
    }

    public async ValueTask<ChoiceResultDTO> ModifyAsync(ChoiceUpdateDTO dto)
    {
        var existChoice = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));
        var existQuestion = await this.questionRepository.GetAsync(u => u.Id.Equals(dto.QuestionId));

        if (existChoice is null)
            throw new NotFoundException($"This Choice not found Id = {dto.Id}");

        if (existQuestion is null)
            throw new NotFoundException($"This Question not found Id = {dto.QuestionId}");

        mapper.Map(dto, existChoice);

        this.repository.Update(existChoice);
        await this.repository.SaveAsync();

        var result = mapper.Map<ChoiceResultDTO>(existChoice);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existChoice = await repository.GetAsync(c => c.Id.Equals(id));

        if (existChoice is null)
            throw new NotFoundException($"This Choice not found Id = {id}");

        this.repository.Delete(existChoice);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<ChoiceResultDTO> RetrieveByIdAsync(long id)
    {
        var existChoice = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Question" });

        if (existChoice is null)
            throw new NotFoundException($"This Choice not found Id = {id}");

        var result = mapper.Map<ChoiceResultDTO>(existChoice);
        return result;
    }

    public async ValueTask<IEnumerable<ChoiceResultDTO>> RetrieveAllAsync()
    {
        var Choices = this.repository.GetAll(null, true, new string[] { "Question" });
        var result = mapper.Map<IEnumerable<ChoiceResultDTO>>(Choices);
        return result;
    }

    public async ValueTask<ChoiceResultDTO> RetrieveCorrectChoiceOfQuestionAsync(long questionId)
    {
        var existChoice = await this.repository.GetAsync(c=> c.QuestionId.Equals(questionId) && c.IsCorrect == true);

        if(existChoice is null)
            throw new NotFoundException($"This Choice not found");

        var result = mapper.Map<ChoiceResultDTO>(existChoice);
        return result;
    }
}
