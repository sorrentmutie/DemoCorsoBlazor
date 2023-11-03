using DemoCorsoBlazor.Library.Models;
using Microsoft.AspNetCore.Components;

namespace DemoCorsoBlazor.Library.Shared;

public class Series : ComponentBase, IDisposable
{
    [Parameter] public List<double> Values { get; set; }
    [CascadingParameter] public Chart ChartFather { get; set; }

    private SeriesData seriesData = new SeriesData();


    protected override void OnInitialized()
    {
        ChartFather.ChartData.Series = new List<SeriesData>();
    }

    protected override void OnParametersSet()
    {
        seriesData.Data = Values;
        ChartFather?.ChartData.Series.Add(seriesData);
    }

    public void Dispose()
    {
        ChartFather.ChartData.Series.Remove(seriesData);
    }
}
