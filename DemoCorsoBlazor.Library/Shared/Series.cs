using DemoCorsoBlazor.Library.Models;
using Microsoft.AspNetCore.Components;

namespace DemoCorsoBlazor.Library.Shared;

public class Series : ComponentBase, IDisposable
{
    [Parameter] public List<double>? Values { get; set; }
    [CascadingParameter] public Chart ChartFather { get; set; }

    private SeriesData seriesData = new SeriesData();


    protected override void OnInitialized()
    {
        if (ChartFather != null && ChartFather.ChartData.Series == null)
        {
            ChartFather.ChartData.Series = new List<SeriesData>();
        }
        ChartFather?.ChartData.Series.Add(seriesData);
    }

    protected override void OnParametersSet()
    {
        if(Values != null)
        {
            seriesData.Data = Values;
        }
        
    }

    public void Dispose()
    {
        ChartFather.ChartData.Series.Remove(seriesData);
    }
}
