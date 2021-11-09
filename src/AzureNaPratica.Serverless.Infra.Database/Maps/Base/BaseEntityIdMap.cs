using AzureNaPratica.Serverless.Domain.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace AzureNaPratica.Serverless.Infra.Database.Maps.Base
{
    public class BaseEntityIdMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseEntityId<string>>(map =>
            {
                map.AutoMap();

                map
                .MapIdProperty(x => x.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance);

                map
                .IdMemberMap
                .SetSerializer(new StringSerializer().WithRepresentation(BsonType.ObjectId));

                map
                .MapMember(x => x.CreatedAt)
                .SetElementName("createdAt")
                .SetIgnoreIfNull(false)
                .SetIsRequired(true)
                .SetSerializer(new DateTimeSerializer(dateOnly: false));

                map
                .MapMember(x => x.ModifiedAt)
                .SetElementName("modifiedAt")
                .SetIgnoreIfNull(false)
                .SetIsRequired(true)
                .SetSerializer(new DateTimeSerializer(dateOnly: false));
            });
        }
    }
}
