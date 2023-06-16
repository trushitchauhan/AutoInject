using Microsoft.Extensions.DependencyInjection;
using System;
using DIAutoInjector.InstallerModules;

namespace DIAutoInjector.Attributes
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
