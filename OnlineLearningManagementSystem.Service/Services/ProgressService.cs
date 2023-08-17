using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Enrollments;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Domain.Entities.Progresses;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;

namespace OnlineLearningManagementSystem.Service.Services;

public class ProgressService : IProgressService
{
    private readonly IRepository<ProgressEntity> repository;
    private readonly IRepository<LessonEntity> lessonRepository;
    private readonly IRepository<EnrollmentEntity> enrollmentRepository;
    private readonly IMapper mapper;

    public ProgressService(IRepository<ProgressEntity> repository, IRepository<LessonEntity> lessonRepository, IRepository<EnrollmentEntity> enrollmentRepository)
    {
        this.repository = repository;
        this.lessonRepository = lessonRepository;
        this.enrollmentRepository = enrollmentRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<ProgressResultDTO> AddAsync(ProgressCreationDTO dto)
    {
        var existLesson = await this.lessonRepository.GetAsync(c => c.Id.Equals(dto.LessonId));
        var existEnrollment = await this.enrollmentRepository.GetAsync(u => u.Id.Equals(dto.EnrollmentId));

        if (existLesson is null)
            throw new NotFoundException($"This Lesson not found Id = {dto.LessonId}");

        if (existEnrollment is null)
            throw new NotFoundException($"This Enrollment not found Id = {dto.EnrollmentId}");

        var entity = mapper.Map<ProgressEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<ProgressResultDTO>(entity);
        return result;
    }

    public async ValueTask<ProgressResultDTO> ModifyAsync(ProgressUpdateDTO dto)
    {
        var existProgress = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));
        var existLesson = await this.lessonRepository.GetAsync(c => c.Id.Equals(dto.LessonId));
        var existEnrollment = await this.enrollmentRepository.GetAsync(u => u.Id.Equals(dto.EnrollmentId));

        if (existProgress is null)
            throw new NotFoundException($"This Progress not found Id = {dto.Id}");

        if (existLesson is null)
            throw new NotFoundException($"This Lesson not found Id = {dto.LessonId}");

        if (existEnrollment is null)
            throw new NotFoundException($"This Enrollment not found Id = {dto.EnrollmentId}");

        mapper.Map(dto, existProgress);

        this.repository.Update(existProgress);
        await this.repository.SaveAsync();

        var result = mapper.Map<ProgressResultDTO>(existProgress);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existProgress = await repository.GetAsync(c => c.Id.Equals(id));

        if (existProgress is null)
            throw new NotFoundException($"This Progress not found Id = {id}");

        this.repository.Delete(existProgress);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<ProgressResultDTO> RetrieveByIdAsync(long id)
    {
        var existProgress = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Progress", "Enrollment" });

        if (existProgress is null)
            throw new NotFoundException($"This Progress not found Id = {id}");

        var result = mapper.Map<ProgressResultDTO>(existProgress);
        return result;
    }

    public async ValueTask<IEnumerable<ProgressResultDTO>> RetrieveAllAsync()
    {
        var Progresss = this.repository.GetAll(null, true, new string[] { "Progress", "Enrollment" });
        var result = mapper.Map<IEnumerable<ProgressResultDTO>>(Progresss);
        return result;
    }

    public async ValueTask<bool> IsComplectedLessonAsync(long lessonId)
    {
        var existProgress = await this.repository.GetAsync(p => p.LessonId.Equals(lessonId));

        if (existProgress is null)
            throw new NotFoundException("This Progress not found");

        return existProgress.IsComplected;
    }
}
