using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Domain.Entities.Lessons;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;

namespace OnlineLearningManagementSystem.Service.Services;

public class LessonService : ILessonService
{
    private readonly IRepository<LessonEntity> repository;
    private readonly IRepository<CourseEntity> courseRepository;
    private readonly IMapper mapper;

    public LessonService(IRepository<LessonEntity> repository, IRepository<CourseEntity> courseRepository)
    {
        this.repository = repository;
        this.courseRepository = courseRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<LessonResultDTO> AddAsync(LessonCreationDTO dto)
    {
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        var entity = mapper.Map<LessonEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<LessonResultDTO>(entity);
        return result;
    }

    public async ValueTask<LessonResultDTO> ModifyAsync(LessonUpdateDTO dto)
    {
        var existLesson = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));

        if (existLesson is null)
            throw new NotFoundException($"This Lesson not found Id = {dto.Id}");

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        mapper.Map(dto, existLesson);

        this.repository.Update(existLesson);
        await this.repository.SaveAsync();

        var result = mapper.Map<LessonResultDTO>(existLesson);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existLesson = await repository.GetAsync(c => c.Id.Equals(id));

        if (existLesson is null)
            throw new NotFoundException($"This Lesson not found Id = {id}");

        this.repository.Delete(existLesson);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<LessonResultDTO> RetrieveByIdAsync(long id)
    {
        var existLesson = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Course", "Progresses" });

        if (existLesson is null)
            throw new NotFoundException($"This Lesson not found Id = {id}");
        
        var result = mapper.Map<LessonResultDTO>(existLesson);
        return result;
    }

    public async ValueTask<IEnumerable<LessonResultDTO>> RetrieveAllAsync()
    {
        var Lessons = this.repository.GetAll(null, true , new string[] { "Course" , "Progresses"});
        var result = mapper.Map<IEnumerable<LessonResultDTO>>(Lessons);
        return result;
    }

    public async ValueTask<IEnumerable<LessonResultDTO>> RetrieveProgressesOfLessonAsync(long id)
    {
        var lessons = this.repository.GetAll(l => l.Id.Equals(id), true, new string[] { "Progresses" });
        var result = mapper.Map<IEnumerable<LessonResultDTO>>(lessons);
        return result;
    }
}
