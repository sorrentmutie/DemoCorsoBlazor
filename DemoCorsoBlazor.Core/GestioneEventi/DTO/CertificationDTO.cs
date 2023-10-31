namespace DemoCorsoBlazor.Core.GestioneEventi.DTO;

public class EventoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Località { get; set; } = string.Empty;
    public List<SpeakerDTO> Speakers { get; set; } = new();
}

public class EventoDTOCreate
{
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Località { get; set; } = string.Empty;
    public List<SpeakerDTOCreate> Speakers { get; set; } = new();
}


public class SpeakerDTO {

    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public List<Certification> Certifications { get; set; } = new();
}

public class SpeakerDTOCreate
{
    public string Nome { get; set; } = null!;
    public List<CertificationDTOCreate> Certifications { get; set; } = new();
}

public class CertificationDTOCreate
{
    public string Nome { get; set; } = null!;
}

public class CertificationDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
}
