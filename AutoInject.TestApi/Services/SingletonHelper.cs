using AutoInject.Attributes;

namespace AutoInject.TestApi.Services
{
    public interface ISingletonHelper : IIdentity
    {
        void Method();
    }

    [Injectable(ServiceLifetime.Singleton)]
    public class SingletonHelper : ISingletonHelper
    {
        public string InstanceId { get; } = Guid.NewGuid().ToString();
        public void Method()
        {
            Console.WriteLine(this.GetType().FullName);
        }
    }
}
