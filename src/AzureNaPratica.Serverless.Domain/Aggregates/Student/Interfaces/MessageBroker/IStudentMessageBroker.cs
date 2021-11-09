using AzureNaPratica.Serverless.Domain.Base.Interfaces.MessageBroker;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.MessageBroker
{
    public interface IStudentMessageBroker : IBaseMessageBroker<Student.Entities.Student, string>
    {
        
    }
}
