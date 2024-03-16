using Infrastructure.Factories;
using Infrastructure.interfaces;
using Infrastructure.interfaces.Factories;
using Infrastructure.interfaces.repository;
using Infrastructure.interfaces.Services;
using Infrastructure.repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepoDb;


namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        GlobalConfiguration
            .Setup()
            .UseSqlite();

        return services
            .AddSingleton<IConnectionFactory, ConnectionFactory>()
            .AddRepositories()
            .AddServices();
    }
    
        private static IServiceCollection AddRepositories(this IServiceCollection @this)
        {
            return @this.AddTransient<ITaxpayerRepository>(CreateRepository<TaxpayerRepository>)
                .AddTransient<ITaxReceiptRepository>(CreateRepository<TaxReceiptRepository>);
        }
        private static IServiceCollection AddServices(this IServiceCollection @this)
        {
            return @this.AddSingleton<ITaxpayerService, TaxpayerService>()
                .AddSingleton<ITaxReceiptService, TaxReceiptService>();
        }

    
    private static T CreateRepository<T>(IServiceProvider serviceProvider)
    {
        var connectionFactory = serviceProvider.GetService<IConnectionFactory>();
        var connection = connectionFactory!.CreateConnection("dgii-db");
        return (T) Activator.CreateInstance(typeof(T), connection)!;
    }
    
}
