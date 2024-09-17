using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ORION.Domain.Tools
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddAllRepositories
            (this IServiceCollection service, Assembly assembly)
        {
            var repositories = assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsClass
                && typeof(IRepository).IsAssignableFrom(x));
            foreach (var repository in repositories)
            {
                var repositoryInterface = repository
                    .GetInterfaces()
                    .SingleOrDefault(i => !i.IsGenericType && typeof(IRepository) != i 
                                                           && typeof(IRepository).IsAssignableFrom(i));
                if (repositoryInterface != null)
                {
                    service.AddScoped(repositoryInterface, repository);
                }
            }
            return service;
        }
    }
}
