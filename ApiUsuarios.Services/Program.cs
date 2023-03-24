using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Services;
using ApiUsuarios.Domain.Interfaces.Repositories;
using ApiUsuarios.Domain.Interfaces.Services;
using ApiUsuarios.Domain.Services;
using ApiUsuarios.Infra.Data.Repositories;
using ApiUsuarios.Services.Configurations.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando a configuração do JWT
JwtConfiguration.Configure(builder);

// Habilitando o AutoMapper no sistema
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adicionando as injeções de dependência do sistema
builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//tornar a classe Program.cs pública
public partial class Program { }



