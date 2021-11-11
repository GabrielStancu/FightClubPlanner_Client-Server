using Infrastructure.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public static class EventHandlingModule
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<Mediator>();
            services.AddScoped<IEventHandler<InviteAnswered>, InviteAnsweredHandler>();
        }
    }
}
