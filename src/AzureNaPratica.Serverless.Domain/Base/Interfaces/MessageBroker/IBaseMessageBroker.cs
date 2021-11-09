using AzureNaPratica.Serverless.Domain.Base.Entity;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Base.Interfaces.MessageBroker
{
    public interface IBaseMessageBroker<TEntity, Tid>
        where TEntity : BaseEvent<Tid>
    {
        Task SendMessage(TEntity requestHttp);
    }
}