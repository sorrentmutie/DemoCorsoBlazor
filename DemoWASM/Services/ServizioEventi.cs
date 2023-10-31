using DemoCorsoBlazor.Core.GestioneEventi;
using System.Net.Http.Json;

namespace DemoWASM.Services;

public class ServizioEventi : IGestioneEventi
{
    private readonly HttpClient httpClient;

    public ServizioEventi(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task AggiungiEventoAsync(Evento evento)
    {
        await httpClient.PostAsJsonAsync("https://localhost:7290/eventi", evento);
    }

    public async Task EliminaEventoAsync(int id)
    {
        await httpClient.DeleteAsync($"https://localhost:7290/eventi/{id}");
    }

    public List<Evento> EstraiEventiFuturi()
    {
       

        return  new List<Evento> {
                 new Evento { Id = 1, Località = "Napoli", Nome = "Corso Blazor", Data = DateTime.Today },
                 new Evento { Id = 2, Località = "Roma", Nome = "Corso MVC", Data = DateTime.Today.AddDays(7) },
                 new Evento { Id = 3, Località = "MIlano", Nome = "Corso ASP.NET", Data = DateTime.Today.AddDays(14) }
        };

}

    public async Task<List<Evento>?> EstraiEventiFuturiAsync()
    {
        var response = await httpClient.GetAsync("https://localhost:7290/eventi");
        if (response == null) return null;
        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Evento>>();

        } else
        {
            return null;
        }
    }

    public List<Evento> EstraiEventiPassati()
    {
        List<Evento> listaEventiPassati =
             new()
                   {
                new Evento { Id = 1, Località = "Napoli", Nome ="Corso Blazor", Data = DateTime.Today.AddDays(-3)},
                new Evento { Id = 2, Località = "Roma", Nome ="Corso MVC", Data = DateTime.Today.AddDays(-7)},
                new Evento { Id = 3, Località = "MIlano", Nome ="Corso ASP.NET", Data = DateTime.Today.AddDays(-14)}
                   };
        return listaEventiPassati;
    }

    public Task<Evento?> EstraiEventoPerId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task ModificaEventoAsync(Evento evento)
    {
        await httpClient.PutAsJsonAsync($"https://localhost:7290/eventi/{evento.Id}", evento);
    }
}

