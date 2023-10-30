using DemoCorsoBlazor.Core.GestioneEventi;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorServer.Data;

public class EventiDbContext: DbContext
{
    public EventiDbContext(DbContextOptions<EventiDbContext> options) : base(options)
    {
        
    }

    public DbSet<Evento> Eventi { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Certification> Certifications { get; set; }

}
