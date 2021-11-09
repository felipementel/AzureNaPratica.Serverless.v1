using AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using static AzureNaPratica.Serverless.Domain.Aggregates.Course.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Infra.Database.Maps.Base
{
    public class CourseMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Course>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);

                map
                .SetIsRootClass(true);

                map.MapCreator(map => new Course(
                    map.Id,
                    map.Name,
                    map.IsActive,
                    map.StartDate,
                    map.ConclusionDate,
                    map.Price,
                    map.Shift));

                map
                .MapMember(x => x.Name)
                .SetElementName("name")
                .SetOrder(2)
                .SetIgnoreIfNull(true)
                .SetIsRequired(false)
                .SetSerializer(new StringSerializer(BsonType.String));

                map
                .MapMember(x => x.IsActive)
                .SetElementName("isActive")
                .SetIgnoreIfNull(true)
                .SetIsRequired(false)
                .SetSerializer(new BooleanSerializer(BsonType.Boolean));

                map
                .MapMember(x => x.StartDate)
                .SetElementName("startDate")
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new DateTimeSerializer(dateOnly: false));

                map
                .MapMember(x => x.ConclusionDate)
                .SetElementName("conclusionDate")
                .SetIgnoreIfNull(true)
                .SetIsRequired(true)
                .SetSerializer(new DateTimeSerializer(dateOnly: false));

                map
                .MapMember(x => x.Price)
                .SetElementName("price")
                .SetIgnoreIfNull(true)
                .SetIsRequired(false)
                .SetSerializer(new DecimalSerializer(BsonType.Decimal128));

                map
                .MapMember(x => x.Shift)
                .SetElementName("shift")
                .SetIgnoreIfNull(false)
                .SetIsRequired(false)
                .SetSerializer(new EnumSerializer<Shift>(BsonType.String));
            });
        }
    }
}
