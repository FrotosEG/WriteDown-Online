using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WriteDownOnlineApi.Infra.CrossCutting;
using WriteDownOnlineApi.Service.Handlers.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InjetarDependenciasExtensions();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateUserHandler).Assembly);

//TODO: Achar uma maneira de fazer a conex�o com o DB pelo railway sem passar a connection string direto no prgram
//string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
var connection = "server=containers-us-west-87.railway.app;port=6759;database=railway;user=root;password=kjesSp24aqrP7h8i7Uyh;Persist Security Info=False; Connect Timeout=300";
builder.Services.AddDbContext<DbContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WriteDown-Online v1");
    });

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
