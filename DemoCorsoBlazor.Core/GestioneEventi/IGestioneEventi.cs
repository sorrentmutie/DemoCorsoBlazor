namespace DemoCorsoBlazor.Core.GestioneEventi;

public interface IGestioneEventi
{
    List<Evento> EstraiEventiFuturi();
    List<Evento> EstraiEventiPassati();
    Task AggiungiEventoAsync(Evento evento);
    Task ModificaEventoAsync(Evento evento);
    Task EliminaEventoAsync(int id);
    Task<List<Evento>?> EstraiEventiFuturiAsync();
    Task<Evento?> EstraiEventoPerId(int id);
}
