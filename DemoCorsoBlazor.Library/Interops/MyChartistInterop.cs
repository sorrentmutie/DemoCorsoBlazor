using DemoCorsoBlazor.Library.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace DemoCorsoBlazor.Library.Interops;

public class MyChartistInterop
{
    private readonly IJSRuntime jSRuntime;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MyChartistInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/DemoCorsoBlazor.Library/myChart.js").AsTask());
    }

    public async Task ShowSimpleChart()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("createChart");
    }

    public async Task ShowChartInElement(ElementReference reference)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("createChart2", reference);
    }

    public async Task ShowChart(ElementReference reference, string chartType, ChartData data)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("createChart3", reference, data, chartType);
    }

    public async Task UpdateChart(ElementReference reference,  ChartData data)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("updateChart", reference, data);
    }

}
