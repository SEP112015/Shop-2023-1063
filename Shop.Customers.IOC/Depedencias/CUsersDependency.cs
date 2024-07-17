using Microsoft.Extensions.DependencyInjection;
using Shop.CUser.Persistence.Repositories;
using Shop.Customers.Application.Interfaces;
using Shop.Customers.Application.Services;
using Shop.Infrastructure.Logger.Interfaces;
using Shop.Infrastructure.Logger.Services;
using Shop.Modules.Domain.Interfaces;

namespace Shop.Customers.IOC.Depedencias
{
    public static class CUsersDependency
    {
        public static void AddCUsersDependency(this IServiceCollection service)
        {
            #region Repositorios
            service.AddScoped<ICustomersRepository, CustomersRepository>();
            service.AddScoped<IUsersRepository, UsersRepository>();
            #endregion

            #region Services
            service.AddTransient<ICustomersService, CustomersServices>();
            service.AddTransient<IUsersServices, UsersServices>();

            #endregion


        }
    }
}
