using System.Threading.Tasks;

namespace CommonDtos.DomainEvent
{
    public interface IEventProvider
    {
        Task Publish(IContent contentObject);
    }
}