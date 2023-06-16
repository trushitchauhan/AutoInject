using Microsoft.Extensions.DependencyInjection;
using System;
using AutoInject.InstallerModules;

namespace AutoInject.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableAttribute : Attribute
    {
        public InjectableAttribute() : this(RegistrationModule.DefaultServiceLifetime) { }

        public InjectableAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }

        public ServiceLifetime ServiceLifetime { get; }
    }
}
