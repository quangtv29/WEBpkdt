using API.Business.Repository.IRepository;
using API.Business.Repository;
using LoggerService;
using API.Business.Services.Interface;
using API.Business.Services;

namespace API.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
 services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
 services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureCustomerService(this IServiceCollection services) =>
services.AddScoped<ICustomerService, CustomerService>();
        public static void ConfigureBillService(this IServiceCollection services) =>
services.AddScoped<IBillService, BillService>();

    }
}
