using AzureNaPratica.Serverless.Application.DataTransferObject.Base;
using System;
using static AzureNaPratica.Serverless.Application.Course.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Application.DataTransferObject.Course
{
    public class CourseDto : BaseDtoId<string>
    {
        public CourseDto(
            Domain.Aggregates.Course.Entities.Course entity)
        {
            Name = entity.Name;
            IsActive = entity.IsActive;
            StartDate = entity.StartDate;
            ConclusionDate = entity.ConclusionDate;
            Price = entity.Price;
            Shift = (AzureNaPratica.Serverless.Application.Course.ValueObjects.Enumerations.Shift)entity.Shift;
        }

        public string Name { get; internal set; }

        public bool IsActive { get; internal set; }

        public DateTime StartDate { get; internal set; }

        public DateTime ConclusionDate { get; internal set; }

        public decimal Price { get; internal set; }

        public Shift Shift { get; internal set; }

        public static implicit operator Domain.Aggregates.Course.Entities.Course(CourseDto dto) =>
            new (
                dto.Name,
                dto.IsActive,
                dto.StartDate,
                dto.ConclusionDate,
                dto.Price,
                (Domain.Aggregates.Course.ValueObjects.Enumerations.Shift)dto.Shift);

        public static implicit operator CourseDto(Domain.Aggregates.Course.Entities.Course entity) =>
            new(entity);
    }
}
