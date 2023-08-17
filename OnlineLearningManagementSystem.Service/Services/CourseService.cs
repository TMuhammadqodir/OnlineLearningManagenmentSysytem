using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;
using System.Runtime.CompilerServices;

namespace OnlineLearningManagementSystem.Service.Services;

public class CourseService : ICourseService
{
    private readonly IRepository<CourseEntity> repository;
    private readonly IMapper mapper;

    public CourseService(IRepository<CourseEntity> repository)
    {
        this.repository = repository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<CourseResultDTO> AddAsync(CourseCreationDTO dto)
    {
        var entity = mapper.Map<CourseEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<CourseResultDTO>(entity);
        return result;
    }

    public async ValueTask<CourseResultDTO> ModifyAsync(CourseUpdateDTO dto)
    {
        var existCourse = await this.repository.GetAsync(c => c.Id.Equals(dto.Id));

        if (existCourse is null)
           throw new NotFoundException($"This Course not found Id = {dto.Id}");

        mapper.Map(dto, existCourse);

        this.repository.Update(existCourse);
        await this.repository.SaveAsync();

        var result = mapper.Map<CourseResultDTO>(existCourse);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existCourse = await repository.GetAsync(c => c.Id.Equals(id));

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {id}");

        this.repository.Delete(existCourse);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<CourseResultDTO> RetrieveByIdAsync(long id)
    {
        var existCourse = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Assiginments", "Quizzes", "Lessons", "Enrollments" });
        
        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {id}");

        var result = mapper.Map<CourseResultDTO>(existCourse);
        return result;
    }

    public async ValueTask<IEnumerable<CourseResultDTO>> RetrieveAllAsync()
    {
        var courses = this.repository.GetAll(null, true, new string[] { "Assiginments", "Quizzes", "Lessons", "Enrollments" });
        var result = mapper.Map<IEnumerable<CourseResultDTO>>(courses);
        return result;
    }

    public async ValueTask<IEnumerable<CourseResultDTO>> RetrieveLessonsOfCourseAsync(long courseId)
    {
        var courses = this.repository.GetAll(c => c.Id.Equals(courseId), true , new string[] { "Lessons" });
        var result = mapper.Map<IEnumerable<CourseResultDTO>>(courses);
        return result;
    }

    public async ValueTask<IEnumerable<CourseResultDTO>> RetrieveQuizzesOfCourseAsync(long courseId)
    {
        var courses = this.repository.GetAll(c => c.Id.Equals(courseId), true, new string[] { "Quizzes" });
        var result = mapper.Map<IEnumerable<CourseResultDTO>>(courses);
        return result;
    }

    public async ValueTask<IEnumerable<CourseResultDTO>> RetrieveAssiginmentsOfCourseAsync(long courseId)
    {
        var courses = this.repository.GetAll(c => c.Id.Equals(courseId), true, new string[] { "Assiginments" });
        var result = mapper.Map<IEnumerable<CourseResultDTO>>(courses);
        return result;
    }
}
