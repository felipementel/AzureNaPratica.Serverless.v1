using AzureNaPratica.Serverless.Application.Base.Interfaces.Service;
using AzureNaPratica.Serverless.Application.DataTransferObject.Student;
using AzureNaPratica.Serverless.Application.Interfaces.Student;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Application.Services.Course
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task DeleteAsync(string id) =>
            await _studentService.DeleteAsync(id);

        public Task<IList<StudentDto>> FindByPredicateAsync(Expression<Func<StudentDto, bool>> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<StudentDto>> GetAllAsync()
        {
            var item = await _studentService.GetAllAsync();
            return item.Select(c => new StudentDto(c)).ToList();
        }

        public async Task<StudentDto> GetByIdAsync(string id) =>
            await _studentService.GetByIdAsync(id);

        public async Task<StudentDto> InsertAsync(StudentDto entity) =>
            await _studentService.InsertAsync(entity);

        public async Task UpdateAsync(StudentDto entity) =>
            await _studentService.UpdateAsync(entity);

        Task<StudentDto> IBaseAppService<StudentDto, string>.UpdateAsync(StudentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
