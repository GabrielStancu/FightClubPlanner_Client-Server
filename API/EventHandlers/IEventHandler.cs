using Infrastructure.DTOs;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public interface IEventHandler<T>
    {
        Task HandleRequestAsync(T request);
    }
}