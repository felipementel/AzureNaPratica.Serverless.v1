using AzureNaPratica.Serverless.Application.Base.Interfaces.Service;
using AzureNaPratica.Serverless.Application.DataTransferObject.Course;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AzureNaPratica.Serverless.Application.Interfaces.Course;

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
            await _courseService.DeleteAsync(Guid.Parse(id));


        public async Task<IList<CourseDto>> GetAllAsync()
        {
            var item = await _courseService.GetAllAsync();
            return item.Select(c => new CourseDto(c)).ToList();
        }

        public async Task<CourseDto> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertAsync(CourseDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(CourseDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
