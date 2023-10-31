using System.ComponentModel.DataAnnotations;

namespace DemoCorsoBlazor.Core.GestioneEventi;

public class Evento
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [StringLength(50, ErrorMessage = "Il nome non può superare i 50 caratteri")]
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Località { get; set; } = string.Empty;
    public List<Speaker> Speakers { get; set; } = new();    
}
