using DemoCorsoBlazor.API.Models;
using DemoCorsoBlazor.Core.GestioneEventi.DTO;
using Microsoft.EntityFrameworkCore;
using DemoCorsoBlazor.Core.GestioneEventi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EventiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/eventi", async (EventiContext database) =>
{
    var eventi = (await database.Eventi.ToListAsync());
    return Results.Ok(eventi.ConvertiInDTO());
});

app.MapPost("/eventi", async (EventiContext database, Eventi evento) =>
{
    if(evento == null)
    {
        return Results.BadRequest();
    }

    try
    {
        await database.Eventi.AddAsync(evento);
        await database.SaveChangesAsync();
        return Results.Ok(evento);

    }
    catch 
    {

        return Results.StatusCode(500);
    }

});



app.Run();


