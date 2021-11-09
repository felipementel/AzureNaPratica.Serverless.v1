using AzureNaPratica.Serverless.Domain.Base.Entity;
using System;
using static AzureNaPratica.Serverless.Domain.Aggregates.Course.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities
{
    public record Course : BaseEntityId<string>
    {
        public Course(
            string id,
            string name,
            bool isActive,
            DateTime startDate,
            DateTime conclusionDate,
            decimal price,
            Shift shift = default)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            StartDate = startDate;
            ConclusionDate = conclusionDate;
            Price = price;
            Shift = shift;
        }

        public Course(
            string name,
            bool isActive,
            DateTime startDate,
            DateTime conclusionDate,
            decimal price, Shift shift = default)
        {
            Name = name;
            IsActive = isActive;
            StartDate = startDate;
            ConclusionDate = conclusionDate;
            Price = price;
            Shift = shift;
        }

        public string Name { get; init; }

        public bool IsActive { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime ConclusionDate { get; init; }

        public decimal Price { get; init; }

        public Shift Shift { get; init; }
    }
}
