using Azure.Messaging.ServiceBus;
using AzureNaPratica.Serverless.Domain.Base.Entity;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.MessageBroker;
using AzureNaPratica.Serverless.Domain.Configs;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Infra.MessageBroker.Base
{
    public abstract class BaseMessageBroker<TEntity, Tid>
        : IBaseMessageBroker<TEntity, Tid> where TEntity : BaseEvent<Tid>
    {
        private readonly ServiceBusClient _client;

        private readonly ServiceBusSender _sender;

        public BaseMessageBroker(
            IOptions<ConnectionStrings> connectionStrings,
            string topicName)
        {
            _client = new ServiceBusClient(connectionStrings.Value.ServiceBus);
            _sender = _client.CreateSender(topicName);
        }

        public async virtual Task SendMessage(TEntity entity)
        {
            using ServiceBusMessageBatch messageBatch = await _sender.CreateMessageBatchAsync();

            var message = Util.OurSerlialization.Serializer<TEntity>(entity);

            if (!messageBatch.TryAddMessage(new ServiceBusMessage(message)))
            {
                throw new Exception($"The message is too large to fit in the batch on {DateTime.UtcNow}");
            }

            try
            {
                await _sender.SendMessagesAsync(messageBatch);

                await Task.CompletedTask;
            }
            finally
            {
                await _sender.DisposeAsync();
                await _client.DisposeAsync();
            }
        }
    }
}
