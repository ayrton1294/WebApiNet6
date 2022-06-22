using webapi.Interface;

namespace webapi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "Hello Word!";
        }
    }
}
