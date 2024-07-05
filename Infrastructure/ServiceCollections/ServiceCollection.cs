using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceCollections;

public static class ServiceCollection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection collection)
  {
    collection.Scan(scan => scan
      .FromApplicationDependencies()
      .AddClasses(classes => classes.AssignableTo(typeof(IEventStoreRepository<>)))
      .AsImplementedInterfaces()
      .WithScopedLifetime());
    
    return collection;
  }
}