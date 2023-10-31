using DemoCorsoBlazor.API.Models;
using DemoCorsoBlazor.Core.GestioneEventi.DTO;
using System.Runtime.CompilerServices;

namespace DemoCorsoBlazor.Core.GestioneEventi;

public static class EventiExtensions
{
    public static List<EventoDTO> ConvertiInDTO( this List<Eventi>evs)
    {
        var listaDTO = new List<EventoDTO>();
        foreach (var ev in evs)
        {
            listaDTO.Add(new EventoDTO { Id = ev.Id, Data = ev.Data, Località = ev.Località, Nome = ev.Nome,
              Speakers = ev.Speakers.Select(s => new SpeakerDTO { Id = s.Id, Nome = s.Nome }).ToList()
            });
        }

        return listaDTO;
    }

    public static Eventi ConvertiDaDTO(this EventoDTOCreate evento)
    {
        return new Eventi
        {
            Nome = evento.Nome,
            Località = evento.Località,
            Data = evento.Data,
            Speakers = evento.Speakers.Select(
              s => new Speakers
              {
                  Nome = s.Nome,
                  Certifications = s.Certifications.Select(
                   c => new Certifications { Nome = c.Nome }).ToList()
              }).ToList()
        };
    }

}
