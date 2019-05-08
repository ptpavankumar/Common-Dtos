using System;

namespace CommonDtos.DomainEvent
{
    public class DomainEvent : IEvent
    {
        public Guid Id { get; set; }
        public IContent Content { get; set; }
    }
}