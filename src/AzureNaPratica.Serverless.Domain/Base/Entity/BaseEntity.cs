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
        public Tid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }

    public abstract record BaseEvent<Tid> : BaseEntityId<Tid>
    {
        public DateTime EventDate { get; private set; }

        public EventType EventType { get; private set; }

        public void SetEventDate(DateTime value)
        {
            EventDate = value;
        }

        public void SetEventType(EventType value)
        {
            EventType = value;
        }
    }

    public enum EventType
    {
        create = 1,
        update,
        delete
    }
}