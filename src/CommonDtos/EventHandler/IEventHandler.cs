using System.Threading.Tasks;

namespace CommonDtos.EventHandler
{
    public interface IEventHandler
    {
        Task Process(string message);
    }
}