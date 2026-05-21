using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Services;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Modules;

namespace Todo.Application.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            services.AddInfrastructureModules();
            services.AddScoped<ITodoService, TodoService>();
            return services;
        }
    }
}
