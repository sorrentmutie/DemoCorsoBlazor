using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace DemoCorsoBlazor.Library.Interops;

public class MyJavaScriptInterops: IDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? objRef;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MyJavaScriptInterops(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/DemoCorsoBlazor.Library/myFunctions.js").AsTask());
    }

    public async Task InvocaPrimaFunzione()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("primaFunzione");
    }

    public async Task<int> InvocaSecondaFunzione(int a, int b)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<int>("secondaFunzione", a, b);
    }

    public async Task InvocaTerzaFunzione()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("terzaFunzione");
    }


    public async Task InvocaQuartaFunzione(string name)
    {
        var module = await moduleTask.Value;
        var instance = new HelloHelper(name);  
        objRef = DotNetObjectReference.Create(instance);
        await module.InvokeVoidAsync("quartaFunzione", objRef);
    }


    public async Task ApriModale(string id)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showModal", id);
    }

    public async Task ChiudiModale()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("hideModal");
    }

    public void Dispose()
    {
        objRef?.Dispose();
    }
}
