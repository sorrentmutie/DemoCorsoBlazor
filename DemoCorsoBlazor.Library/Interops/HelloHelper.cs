using Microsoft.JSInterop;

namespace DemoCorsoBlazor.Library.Interops;

public class HelloHelper
{
    public HelloHelper(string name)
    {
        Name = name;
    }

    public string Name { get; }

    [JSInvokable]
    public string SayHello()
    {
        return $"Hello {Name}!";
    }   
}
