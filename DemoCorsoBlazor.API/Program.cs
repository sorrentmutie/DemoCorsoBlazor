using DemoCorsoBlazor.API.Models;
using Microsoft.EntityFrameworkCore;
using DemoCorsoBlazor.Core.GestioneEventi;
using DemoCorsoBlazor.Core.GestioneEventi.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EventiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapGet("/eventi", async (EventiContext database) =>
{
    var eventi = (await database.Eventi.ToListAsync());
    return Results.Ok(eventi.ConvertiInDTO());
});

app.MapPost("/eventi", async (EventiContext database,
    EventoDTOCreate evento) =>
{
    if(evento == null) return Results.BadRequest();
    
    try
    {
        var eventoDb = evento.ConvertiDaDTO();
        database.Eventi.Add(eventoDb);
        await database.SaveChangesAsync();
        return Results.StatusCode(201);
    }
    catch (Exception ex)
    {
        return Results.StatusCode(500);
    }

});


app.MapPut("/eventi/{id}", async (EventiContext database, EventoDTO evento, int id) =>
{
    var eventoDb = new Eventi
    {
        Id = evento.Id,
        Nome = evento.Nome,
        Località = evento.Località,
        Data = evento.Data,
        //Speakers = evento.Speakers.Select(
        //      s => new Speakers
        //      {
        //          Id = s.Id,
        //          Nome = s.Nome,
        //          Certifications = s.Certifications.Select(
        //           c => new Certifications { Id= c.Id,  Nome = c.Nome }).ToList()
        //      }).ToList()
    };

    database.Eventi.Update(eventoDb);
    await database.SaveChangesAsync();

   

    foreach (var speakerDTO in evento.Speakers)
    {
        Speakers speakers = new Speakers
        {
            Nome = speakerDTO.Nome,
            EventoId = evento.Id
        };

        if (speakerDTO.Id == 0)
        {
            
            database.Speakers.Add(speakers);
        } else
        {
            speakers.Id = speakerDTO.Id;
            database.Speakers.Update(speakers);
        }
        await database.SaveChangesAsync();
        
    }


        
      
    await database.SaveChangesAsync();

});

app.MapDelete("/eventi/{id}", async (EventiContext database, int id) => { 
    Eventi evento = new Eventi { Id = id };
    database.Eventi.Remove(evento);
    await database.SaveChangesAsync();
});



app.Run();


