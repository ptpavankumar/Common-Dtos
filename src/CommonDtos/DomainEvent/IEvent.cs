using System;

namespace CommonDtos.DomainEvent
{
    public interface IEvent
    {
        Guid Id { get; set; }
        IContent Content { get; set; }
    }
}