using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Users;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;

namespace OnlineLearningManagementSystem.Service.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IRepository<EnrollmentEntity> repository;
    private readonly IRepository<CourseEntity> courseRepository;
    private readonly IRepository<UserEntity> userRepository;
    private readonly IMapper mapper;

    public EnrollmentService(IRepository<EnrollmentEntity> repository, IRepository<CourseEntity> courseRepository, IRepository<UserEntity> userRepository)
    {
        this.repository = repository;
        this.courseRepository = courseRepository;
        this.userRepository = userRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<EnrollmentResultDTO> AddAsync(EnrollmentCreationDTO dto)
    {
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));
        var existUser = await this.userRepository.GetAsync(u => u.Id.Equals(dto.UserId));

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        if (existUser is null)
            throw new NotFoundException($"This User not found Id = {dto.CourseId}");

        var entity = mapper.Map<EnrollmentEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<EnrollmentResultDTO>(entity);
        return result;
    }

    public async ValueTask<EnrollmentResultDTO> ModifyAsync(EnrollmentUpdateDTO dto)
    {
        var existEnrollment = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));
        var existUser = await this.userRepository.GetAsync(u => u.Id.Equals(dto.UserId));

        if (existEnrollment is null)
            throw new NotFoundException($"This Enrollment not found Id = {dto.Id}");

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        if (existUser is null)
            throw new NotFoundException($"This User not found Id = {dto.CourseId}");

        mapper.Map(dto, existEnrollment);

        this.repository.Update(existEnrollment);
        await this.repository.SaveAsync();

        var result = mapper.Map<EnrollmentResultDTO>(existEnrollment);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existEnrollment = await repository.GetAsync(c => c.Id.Equals(id));

        if (existEnrollment is null)
            throw new NotFoundException($"This Enrollment not found Id = {id}");

        this.repository.Delete(existEnrollment);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<EnrollmentResultDTO> RetrieveByIdAsync(long id)
    {
        var existEnrollment = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Course", "User", "Enrollments" });

        if (existEnrollment is null)
            throw new NotFoundException($"This Enrollment not found Id = {id}");

        var result = mapper.Map<EnrollmentResultDTO>(existEnrollment);
        return result;
    }

    public async ValueTask<IEnumerable<EnrollmentResultDTO>> RetrieveAllAsync()
    {
        var Enrollments = this.repository.GetAll(null, true, new string[] { "Course", "User", "Enrollments" });
        var result = mapper.Map<IEnumerable<EnrollmentResultDTO>>(Enrollments);
        return result;
    }

    public async ValueTask<int> CountUsersOfCourseAsync(long id)
    {
        var result = this.repository.GetAll(c => c.CourseId.Equals(id));

        return result.Count();
    }

    public async ValueTask<int> CountCourseOfUserAsync(long id)
    {
        var result = this.repository.GetAll(c => c.UserId.Equals(id));

        return result.Count();
    }
}
