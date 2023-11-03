namespace DemoCorsoBlazor.Core.RandomUser;

public class RandomUserViewModel
{
    public List<Utente> Utenti { get; set; } = new();
    public ChartViewModel Genere { get; set; } = new();
    public ChartViewModel TotPerNazione { get; set; } = new();
}

public class ChartViewModel
{
    public List<string> Labels { get; set; } = new();
    public List<double> Values { get; set; } = new();

}