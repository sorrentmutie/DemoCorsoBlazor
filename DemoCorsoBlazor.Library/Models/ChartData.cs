namespace DemoCorsoBlazor.Library.Models;

public class SeriesData
{
    public List<double> Data { get; set; } = new();
}


public class ChartData
{
    public List<string> Labels { get; set; } = new();
    public List<SeriesData> Series { get; set; } = new();
}

public enum ChartType
{
    Line, Bar
} 
