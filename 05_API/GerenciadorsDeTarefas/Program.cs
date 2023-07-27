
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GerenciadorsDeTarefas.Data;
using GerenciadorsDeTarefas.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


//Container de conexão com o banco de dados
var configuration = builder.Configuration;
builder.Services.AddDbContext<GerenciadorsDeTarefasContext>(options => options.UseSqlServer(configuration.GetConnectionString("TarefasDb")));

//Container de injeção de dependência do repositório
builder.Services.AddScoped<ITarefasRepository, TarefaRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
