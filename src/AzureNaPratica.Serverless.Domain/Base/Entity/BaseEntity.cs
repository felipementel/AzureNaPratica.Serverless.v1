using FluentValidation.Results;
using System;

namespace AzureNaPratica.Serverless.Domain.Base.Entity
{
    public abstract record BaseEntity
    {
        public ValidationResult ValidationResult { get; set; }
    }

    public abstract record BaseEntityId<Tid> : BaseEntity
    {
        public Tid Id { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; } = DateTime.UtcNow;        
    }
}