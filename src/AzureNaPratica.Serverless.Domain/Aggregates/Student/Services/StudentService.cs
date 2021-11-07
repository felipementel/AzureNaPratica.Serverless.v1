using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Services
{
    public class StudentService : IStudentService
    {
        public Task<Entities.Student> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Entities.Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Student> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Student> InsertAsync(Entities.Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Student> UpdateAsync(Entities.Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
