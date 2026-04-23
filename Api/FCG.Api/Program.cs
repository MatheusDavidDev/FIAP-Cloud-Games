using FCG.Api.Middlewares;
using FCG.Application.Commands.JogoCommand.CriarJogo;
using FCG.Application.Commands.JogoCommand.EditarJogo;
using FCG.Application.Commands.JogoCommand.ExcluirJogo;
using FCG.Application.Commands.UsuarioCommand.AdicionarJogo;
using FCG.Application.Commands.UsuarioCommand.CriarUsuario;
using FCG.Application.Commands.UsuarioCommand.EditarUsuario;
using FCG.Application.Commands.UsuarioCommand.ExcluirUsuario;
using FCG.Application.Interfaces;
using FCG.Core.Behaviors;
using FCG.Core.UnitOfWork;
using FCG.Infra;
using FCG.Infra.Security;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FcgDbContext>(options => options.UseSqlServer(connectionString));

#region DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<FcgDbContext>>();
builder.Services.AddScoped<IHashSenha, HashSenha>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
#endregion

#region MEDIATR
//Usuario
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarUsuarioHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CriarUsuarioValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EditarUsuarioHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(EditarUsuarioValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ExcluirUsuarioHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(ExcluirUsuarioValidator).Assembly);

//Jogo
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CriarJogoValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EditarJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(EditarJogoValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ExcluirJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(ExcluirJogoValidator).Assembly);

//Biblioteca
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AdicionarJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(AdicionarJogoValidator).Assembly);

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
