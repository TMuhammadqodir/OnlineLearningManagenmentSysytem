using AutoMapper;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Entities.Assiginments;
using OnlineLearningManagementSystem.Domain.Entities.Courses;
using OnlineLearningManagementSystem.Service.Exceptions;
using OnlineLearningManagementSystem.Service.IServices;
using OnlineLearningManagementSystem.Service.Mappers;
using System.Runtime.InteropServices.ComTypes;

namespace OnlineLearningManagementSystem.Service.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IRepository<AssiginmentEntity> repository;
    private readonly IRepository<CourseEntity> courseRepository;
    private readonly IMapper mapper;

    public AssignmentService(IRepository<AssiginmentEntity> repository, IRepository<CourseEntity> courseRepository)
    {
        this.repository = repository;
        this.courseRepository = courseRepository;

        mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async ValueTask<AssiginmentResultDTO> AddAsync(AssiginmentCreationDTO dto)
    {
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        var entity = mapper.Map<AssiginmentEntity>(dto);

        await this.repository.CreateAsync(entity);
        await this.repository.SaveAsync();

        var result = mapper.Map<AssiginmentResultDTO>(entity);
        return result;
    }

    public async ValueTask<AssiginmentResultDTO> ModifyAsync(AssiginmentUpdateDTO dto)
    {
        var existAssiginment = await this.repository.GetAsync(a => a.Id.Equals(dto.Id));
        var existCourse = await this.courseRepository.GetAsync(c => c.Id.Equals(dto.CourseId));

        if (existAssiginment is null)
            throw new NotFoundException($"This Assiginment not found Id = {dto.Id}");

        if (existCourse is null)
            throw new NotFoundException($"This Course not found Id = {dto.CourseId}");

        mapper.Map(dto, existAssiginment);

        this.repository.Update(existAssiginment);
        await this.repository.SaveAsync();

        var result = mapper.Map<AssiginmentResultDTO>(existAssiginment);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existAssiginment = await repository.GetAsync(c => c.Id.Equals(id));

        if (existAssiginment is null)
            throw new NotFoundException($"This Assiginment not found Id = {id}");

        this.repository.Delete(existAssiginment);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<AssiginmentResultDTO> RetrieveByIdAsync(long id)
    {
        var existAssiginment = await this.repository.GetAsync(c => c.Id.Equals(id), new string[] { "Course" });
      
        if (existAssiginment is null)
            throw new NotFoundException($"This Assiginment not found Id = {id}");

        var result = mapper.Map<AssiginmentResultDTO>(existAssiginment);
        return result;
    }

    public async ValueTask<IEnumerable<AssiginmentResultDTO>> RetrieveAllAsync()
    {
        var Assiginments = this.repository.GetAll(null, true, new string[] {"Course"});
        var result = mapper.Map<IEnumerable<AssiginmentResultDTO>>(Assiginments);
        return result;
    }
}
