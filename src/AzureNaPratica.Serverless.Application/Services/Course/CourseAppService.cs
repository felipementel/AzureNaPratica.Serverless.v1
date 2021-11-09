using AzureNaPratica.Serverless.Application.DataTransferObject.Course;
using AzureNaPratica.Serverless.Application.Interfaces.Course;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Application.Services.Course
{
    public class CourseAppService : ICourseAppService
    {
        private readonly ICourseService _courseService;

        public CourseAppService(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task DeleteAsync(string id) =>
            await _courseService.DeleteAsync(id);

        public Task<IList<CourseDto>> FindByPredicateAsync(Expression<Func<CourseDto, bool>> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CourseDto>> GetAllAsync()
        {
            var item = await _courseService.GetAllAsync();
            return item.Select(c => new CourseDto(c)).ToList();
        }

        public async Task<CourseDto> GetByIdAsync(string id) =>
            await _courseService.GetByIdAsync(id);

        public async Task<CourseDto> InsertAsync(CourseDto entity) =>
            await _courseService.InsertAsync(entity);

        public async Task<CourseDto> UpdateAsync(CourseDto entity) =>
            await _courseService.UpdateAsync(entity);
    }
}
