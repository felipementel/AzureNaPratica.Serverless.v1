using AzureNaPratica.Serverless.Domain.Base.Interfaces.Service;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services
{
    public interface ICourseService : IBaseService<Course.Entities.Course, string>
    {
    }
}