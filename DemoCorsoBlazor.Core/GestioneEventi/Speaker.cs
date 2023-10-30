namespace DemoCorsoBlazor.Core.GestioneEventi;

public class Certification
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public int SpeakerId { get; set; }
    public List<Speaker> Speakers { get; set; } = new List<Speaker>();
}


public class Speaker
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public int EventoId { get; set; }
    public Evento Evento { get; set; } = null!;
    public List<Certification> Certifications { get; set; } = new();
    

}
