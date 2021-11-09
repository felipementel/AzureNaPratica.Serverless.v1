using AzureNaPratica.Serverless.Domain.Aggregates.Student.Entities;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.MessageBroker;
using AzureNaPratica.Serverless.Domain.Configs;
using AzureNaPratica.Serverless.Infra.MessageBroker.Base;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Infra.MessageBroker
{
    public class StudentMessageBroker : BaseMessageBroker<Student, string>, IStudentMessageBroker
    {
        public StudentMessageBroker(
            IOptions<ConnectionStrings> connectionStrings,
            IOptions<ApplicationSettings> applicationSettings) : base(connectionStrings, applicationSettings.Value.TopicStudent)
        {

        }

        public override Task SendMessage(Student entity)
        {
            entity.SetEventDate(System.DateTime.Now);

            return base.SendMessage(entity);
        }
    }
}