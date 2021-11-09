using AzureNaPratica.Serverless.Domain.Base.Entity;
using MongoDB.Bson.Serialization;

namespace AzureNaPratica.Serverless.Infra.Database.Maps.Base
{
    public class BaseEventMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseEvent<string>>(map =>
            {
                map
                .UnmapMember(v => v.EventType);

                map
                .UnmapMember(v => v.EventDate);
            });
        }
    }
}
