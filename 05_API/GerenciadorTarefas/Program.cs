using GerenciadorTarefas.Database;
using GerenciadorTarefas.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("TarefasDB");
builder.Services.AddDbContext<GerenciadorTarefasContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion
#region Injeção de dependência
builder.Services.AddScoped<ITarefasRepositoy, TarefasRepository>();//Repositório
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//AutoMapper
#endregion
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
