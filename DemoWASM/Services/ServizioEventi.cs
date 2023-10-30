﻿using DemoCorsoBlazor.Core.GestioneEventi;

namespace DemoWASM.Services;

public class ServizioEventi : IGestioneEventi
{
    public Task AggiungiEventoAsync(Evento evento)
    {
        throw new NotImplementedException();
    }

    public Task EliminaEventoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<Evento> EstraiEventiFuturi()
    {
        return  new List<Evento> {
                 new Evento { Id = 1, Località = "Napoli", Nome = "Corso Blazor", Data = DateTime.Today },
                 new Evento { Id = 2, Località = "Roma", Nome = "Corso MVC", Data = DateTime.Today.AddDays(7) },
                 new Evento { Id = 3, Località = "MIlano", Nome = "Corso ASP.NET", Data = DateTime.Today.AddDays(14) }
        };

}

    public Task<List<Evento>?> EstraiEventiFuturiAsync()
    {
        throw new NotImplementedException();
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

    public Task ModificaEventoAsync(Evento evento)
    {
        throw new NotImplementedException();
    }
}

