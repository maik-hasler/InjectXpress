using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InjectXpress;

public interface IServiceCollectionInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration);
}
