namespace DemoCorsoBlazor.Core.GestioneEventi;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Località { get; set; } = string.Empty;
    public List<Speaker> Speakers { get; set; } = new();    
}
