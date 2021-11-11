using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace API.EventHandlers
{
    public class Mediator
    {
        private IServiceProvider _services;

        public Mediator(IServiceProvider services)
        {
            _services = services;
        }

        public Task Handle<T>(T request)
        {
            var handler = _services.GetService<IEventHandler<T>>();
            return handler.HandleRequestAsync(request);
        }
    }
}
