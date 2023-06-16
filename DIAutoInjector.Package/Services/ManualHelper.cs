using DIAutoInjector.Attributes;

namespace DIAutoInjector.Package.Services
{
    public interface IManualHelper : IIdentity
    {
        void Method();
    }

    public class ManualHelper : IManualHelper
    {
        public string InstanceId { get; } = Guid.NewGuid().ToString();
        public string ConnetionString { get; }

        public ManualHelper(string connetionString)
        {
            ConnetionString = connetionString;
        }

        public void Method()
        {
            Console.WriteLine(ConnetionString);
        }
    }
}
