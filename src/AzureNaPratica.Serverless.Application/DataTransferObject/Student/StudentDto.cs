using AzureNaPratica.Serverless.Application.DataTransferObject.Base;
using AzureNaPratica.Serverless.Application.DataTransferObject.Course;
using System;
using System.Text.Json.Serialization;
using static AzureNaPratica.Serverless.Application.Student.ValueObjects.Enumerations;

namespace AzureNaPratica.Serverless.Application.DataTransferObject.Student
{
    public class StudentDto : BaseDtoId<string>
    {
        public StudentDto(
            Domain.Aggregates.Student.Entities.Student entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            EnterDate = entity.EnterDate;
            SexualOrientation = (SexualOrientation)entity.SexualOrientation;
            LucyNumber = entity.LucyNumber;

            CreatedAt = entity.CreatedAt;
            ModifiedAt = entity.ModifiedAt;

            ValidationResult = entity.ValidationResult;
        }

        [JsonConstructor]
        public StudentDto(
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

        public string Name { get; internal set; }

        public DateTime EnterDate { get; internal set; }

        public SexualOrientation SexualOrientation { get; internal set; }

        public int LucyNumber { get; internal set; }

        public static implicit operator Domain.Aggregates.Student.Entities.Student(StudentDto dto) =>
            new(
                dto.Name,
                dto.EnterDate,
                (Domain.Aggregates.Student.ValueObjects.Enumerations.SexualOrientation)dto.SexualOrientation,
                dto.LucyNumber);

        public static implicit operator StudentDto(Domain.Aggregates.Student.Entities.Student entity) =>
            new(entity);
    }
}
