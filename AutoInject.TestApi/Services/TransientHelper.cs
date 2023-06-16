using AutoInject.Attributes;

namespace AutoInject.TestApi.Services
{
    public interface ITransientHelper : IIdentity
    {
        void Method();
    }

    [Injectable]
    public class TransientHelper : ITransientHelper
    {
        public string InstanceId { get; } = Guid.NewGuid().ToString();
        public void Method()
        {
            Console.WriteLine(this.GetType().FullName);
        }
    }
}
