namespace DemoCorsoBlazor.Core.GestioneEventi;

public interface IGestioneEventi
{
    List<Evento> EstraiEventiFuturi();
    List<Evento> EstraiEventiPassati();
}
