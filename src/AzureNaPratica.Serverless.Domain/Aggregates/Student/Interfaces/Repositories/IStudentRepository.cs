using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository;
using System;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student.Entities.Student, Guid>
    {
    }
}