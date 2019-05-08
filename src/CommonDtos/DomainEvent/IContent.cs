namespace CommonDtos.DomainEvent
{
    public interface IContent
    {
        string NameSpace { get; }
        string Version { get; }
        string CorrelationId { get; set; }
    }
}