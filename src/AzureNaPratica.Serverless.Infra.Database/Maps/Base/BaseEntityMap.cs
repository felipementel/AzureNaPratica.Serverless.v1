using AzureNaPratica.Serverless.Domain.Base.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace AzureNaPratica.Serverless.Infra.Database.Maps.Base
{
    public class BaseEntityMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(map =>
            {
                map
                .UnmapMember(v => v.ValidationResult);
            });
        }
    }
}
