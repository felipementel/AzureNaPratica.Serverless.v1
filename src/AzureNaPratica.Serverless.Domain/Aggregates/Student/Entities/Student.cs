using AzureNaPratica.Serverless.Domain.Base.Entity;
using System;
using static AzureNaPratica.Serverless.Domain.Aggregates.Student.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Entities
{
    public record Student : BaseEntityId<Guid>
    {
        public Student(
            string name,
            DateTime enterDate,
            SexualOrientation sexualOrientation,
            Course.Entities.Course course)
        {
            Name = name;
            EnterDate = enterDate;
            SexualOrientation = sexualOrientation;
            Course = course;
        }

        public string Name { get; init; }

        public DateTime EnterDate { get; init; }

        public SexualOrientation SexualOrientation { get; init; }

        public Course.Entities.Course Course { get; init; }
    }
}