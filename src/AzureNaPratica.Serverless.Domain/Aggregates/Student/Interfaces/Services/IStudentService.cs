using AzureNaPratica.Serverless.Domain.Base.Interfaces.Service;
using System;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Services
{
    public interface IStudentService : IBaseService<Student.Entities.Student, Guid>
    {
    }
}
