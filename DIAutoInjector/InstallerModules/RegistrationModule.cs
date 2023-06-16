using DIAutoInjector.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DIAutoInjector.InstallerModules
{
    public static class RegistrationModule
    {
        public static ServiceLifetime DefaultServiceLifetime { get; private set; }
        public static IServiceCollection RegisterDIAutoInjector(this IServiceCollection services, ServiceLifetime defaultServiceLifetime = ServiceLifetime.Transient)
        {
            DefaultServiceLifetime = defaultServiceLifetime;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    var attributes = type.GetCustomAttributes(typeof(InjectableAttribute), true);
                    if (attributes.Any() && attributes.FirstOrDefault() is InjectableAttribute)
                    {
                        var implementationType = type.GetInterfaces().FirstOrDefault(i => !i.IsGenericType);
                        if (implementationType != null)
                        {
                            switch ((attributes.First() as InjectableAttribute).ServiceLifetime)
                            {
                                case ServiceLifetime.Singleton:
                                    services.AddSingleton(implementationType, type);
                                    break;
                                case ServiceLifetime.Scoped:
                                    services.AddScoped(implementationType, type);
                                    break;
                                case ServiceLifetime.Transient:
                                    services.AddTransient(implementationType, type);
                                    break;
                                default:
                                    throw new InvalidOperationException();
                            }
                        }
                    }
                }
            }
            return services;
        }
    }
}
