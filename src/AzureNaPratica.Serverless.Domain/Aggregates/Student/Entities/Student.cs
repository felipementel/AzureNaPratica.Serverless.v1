using AzureNaPratica.Serverless.Domain.Base.Entity;
using System;
using static AzureNaPratica.Serverless.Domain.Aggregates.Student.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Entities
{
    public record Student : BaseEvent<string>
    {
        public Student(
            string id,
            string name,
            DateTime enterDate,
            SexualOrientation sexualOrientation,
            int lucyNumber)
        {
            Id = id;
            Name = name;
            EnterDate = enterDate;
            SexualOrientation = sexualOrientation;
            LucyNumber = lucyNumber;
        }

        public Student(
            string name,
            DateTime enterDate,
            SexualOrientation sexualOrientation,
            int lucyNumber)
        {
            Name = name;
            EnterDate = enterDate;
            SexualOrientation = sexualOrientation;
            LucyNumber = lucyNumber;
        }

        public string Name { get; init; }

        public DateTime EnterDate { get; init; }

        public SexualOrientation SexualOrientation { get; init; }

        public int LucyNumber { get; private set; }

        public void SetLucyNumber(int value)
        {
            LucyNumber = value;
        }
    }
}