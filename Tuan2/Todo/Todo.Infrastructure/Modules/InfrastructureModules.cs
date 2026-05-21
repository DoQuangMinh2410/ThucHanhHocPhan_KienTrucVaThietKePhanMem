using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Repositories;

namespace Todo.Infrastructure.Modules
{
    public static class InfrastructureModules
    {

        public static IServiceCollection AddInfrastructureModules(this IServiceCollection services)
        {
            IServiceCollection serviceCollection = services.AddDbContext<ITodoRepository, TodoRepository>();
            return services;

        }
    }
}
