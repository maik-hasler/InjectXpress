using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InjectXpress;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection InstallServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        var serviceCollectionInstallers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(dt => dt.IsAssignableToType<IServiceCollectionInstaller>())
            .Where(dt => dt.IsInterface == false)
            .Where(dt => dt.IsAbstract == false)
            .Select(Activator.CreateInstance)
            .Cast<IServiceCollectionInstaller>()
            .ToList();

        serviceCollectionInstallers.ForEach(
            sci => sci.Install(
                serviceCollection,
                configuration));

        return serviceCollection;
    }
}
