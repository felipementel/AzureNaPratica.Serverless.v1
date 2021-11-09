using AzureNaPratica.Serverless.Domain.Aggregates.Student.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using static AzureNaPratica.Serverless.Domain.Aggregates.Student.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Infra.Database.Maps.Base
{
    public class StudentMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Student>(map =>
            {
                map.AutoMap();

                map.SetIgnoreExtraElements(true);

                map
                .SetIsRootClass(true);

                map.MapCreator(map => new Student(
                    map.Id,
                    map.Name,
                    map.EnterDate,
                    map.SexualOrientation,
                    map.LucyNumber));

                map
                .MapMember(x => x.Name)
                .SetElementName("name")
                .SetIgnoreIfNull(true)
                .SetIsRequired(false)
                .SetSerializer(new StringSerializer(BsonType.String));

                map
                .MapMember(x => x.EnterDate)
                .SetElementName("enterDate")
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new DateTimeSerializer(dateOnly: false));

                map
                .MapMember(x => x.SexualOrientation)
                .SetElementName("sexualOrientation")
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new EnumSerializer<SexualOrientation>(BsonType.String));

                map
                .MapMember(x => x.LucyNumber)
                .SetElementName("lucyNumber")
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new Int32Serializer(BsonType.Int32));
            });
        }
    }
}
