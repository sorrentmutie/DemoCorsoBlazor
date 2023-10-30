using DemoBlazorServer.Data;
using DemoCorsoBlazor.Core.GestioneEventi;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorServer.Services
{
    public class ServizioEventiServer : IGestioneEventi
    {
        private readonly EventiDbContext database;

        public ServizioEventiServer(EventiDbContext database)
        {
            this.database = database;
        }

        public async Task AggiungiEventoAsync(Evento evento)
        {
            database.Eventi.Add(evento);
            await database.SaveChangesAsync();
        }

        public async Task EliminaEventoAsync(int id)
        {
            var eventoDb = await database.Eventi.FindAsync(id);
            if (eventoDb != null)
            {
                database.Entry(eventoDb).State = EntityState.Deleted;
                await database.SaveChangesAsync();
            }
        }

        public List<Evento> EstraiEventiFuturi()
        {
            return new List<Evento> {
                 new Evento { Id = 1, Località = "Napoli", Nome = "Corso Blazor", Data = DateTime.Today },
                 new Evento { Id = 2, Località = "Roma", Nome = "Corso MVC", Data = DateTime.Today.AddDays(7) },
                 new Evento { Id = 3, Località = "MIlano", Nome = "Corso ASP.NET", Data = DateTime.Today.AddDays(14) }
        };

        }

        public async Task<List<Evento>?> EstraiEventiFuturiAsync()
        {
            return await database.Eventi.ToListAsync();
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

        public async Task<Evento?> EstraiEventoPerId(int id)
        {
            return await database.Eventi.FindAsync(id);
        }

        public async Task ModificaEventoAsync(Evento evento)
        {
            var eventoDb = await database.Eventi.FindAsync(evento.Id);
            if(eventoDb != null)
            {
                database.Entry(eventoDb).State = EntityState.Detached;
                database.Entry(evento).State = EntityState.Modified;
                await database.SaveChangesAsync();
            }
        }
    }
}
