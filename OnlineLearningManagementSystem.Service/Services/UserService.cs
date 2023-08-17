using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Questions;
using OnlineLearningManagementSystem.Domain.Entities.Users;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;

namespace OnlineLearningManagementSystem.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> repository;
    private readonly IMapper mapper;

    public UserService(IRepository<UserEntity> repository)
    {
        this.repository = repository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<UserResultDTO> AddAsync(UserCreationDTO dto)
    {
        var existUser = await repository.GetAsync(u => u.TelNumber.Equals(dto.TelNumber));

        if (existUser is not null)
            throw new AlreadyExistException($"This User already exist Id = {dto.TelNumber}");

        var entity = mapper.Map<UserEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<UserResultDTO>(entity);
        return result;
    }

    public async ValueTask<UserResultDTO> ModifyAsync(UserUpdateDTO dto)
    {
        var existUser1 = await this.repository.GetAsync(u => u.Id.Equals(dto.Id));
        var existUser2 = await this.repository.GetAsync(u => u.TelNumber.Equals(dto) && u.Id!=dto.Id);

        if (existUser1 is null)
            throw new NotFoundException($"This User not found Id = {dto.Id}");

        if (existUser2 is not null)
            throw new AlreadyExistException($"This User already exist Id = {dto.TelNumber}");

        mapper.Map(dto, existUser1);

        this.repository.Update(existUser1);
        await this.repository.SaveAsync();

        var result = mapper.Map<UserResultDTO>(existUser1);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existUser = await repository.GetAsync(c => c.Id.Equals(id));

        if (existUser is null)
            throw new NotFoundException($"This User not found Id = {id}");

        this.repository.Delete(existUser);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<UserResultDTO> RetrieveByIdAsync(long id)
    {
        var existUser = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Quizzes", "Enrollments" });

        if (existUser is null)
            throw new NotFoundException($"This User not found Id = {id}");

        var result = mapper.Map<UserResultDTO>(existUser);
        return result;
    }

    public async ValueTask<IEnumerable<UserResultDTO>> RetrieveAllAsync()
    {
        var Users = this.repository.GetAll(null, true, new string[] {"Quizzes", "Enrollments"});
        var result = mapper.Map<IEnumerable<UserResultDTO>>(Users);
        return result;
    }

    public async ValueTask<IEnumerable<UserResultDTO>> RetrieveQuizzesOfUsersAsync(long userId)
    {
        var users = this.repository.GetAll(u => u.Id.Equals(userId), true, new string[] { "Quizzes" });
        var result = mapper.Map<IEnumerable<UserResultDTO>>(users);
        return result;
    }
}
