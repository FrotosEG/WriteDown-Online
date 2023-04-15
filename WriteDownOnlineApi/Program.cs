using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WriteDownOnlineApi.Infra.CrossCutting;
using WriteDownOnlineApi.Service.Handlers.Usuario;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InjetarDependenciasExtensions();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CriarUsuarioHandler).Assembly);

builder.Services.AddDbContext<DbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
