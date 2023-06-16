using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AutoInject.Attributes;

namespace AutoInject.InstallerModules
{
    public static class RegistrationModule
    {
        public static ServiceLifetime DefaultServiceLifetime { get; private set; }
        public static IServiceCollection RegisterAutoInject(this IServiceCollection services, ServiceLifetime defaultServiceLifetime = ServiceLifetime.Transient)
        {
            DefaultServiceLifetime = defaultServiceLifetime;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttributes(typeof(InjectableAttribute), true);
                    if (attribute.Any() && attribute.FirstOrDefault() is InjectableAttribute)
                    {
                        var intf = type.GetInterfaces().FirstOrDefault(i => !i.IsGenericType);
                        if (intf != null)
                        {
                            switch ((attribute.First() as InjectableAttribute).ServiceLifetime)
                            {
                                case ServiceLifetime.Singleton:
                                    services.AddSingleton(intf, type);
                                    break;
                                case ServiceLifetime.Scoped:
                                    services.AddScoped(intf, type);
                                    break;
                                case ServiceLifetime.Transient:
                                    services.AddTransient(intf, type);
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
