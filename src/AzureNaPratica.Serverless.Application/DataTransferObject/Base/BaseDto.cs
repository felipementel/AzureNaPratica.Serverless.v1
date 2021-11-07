using FluentValidation.Results;
using System;

namespace AzureNaPratica.Serverless.Application.DataTransferObject.Base
{
    public class BaseDto
    {
        public ValidationResult ValidationResult { get; set; }
    }

    public class BaseDtoId<Tid> : BaseDto
    {
        public Tid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}