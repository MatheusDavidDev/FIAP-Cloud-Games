using FCG.Api.Middlewares;
using FCG.Application.Commands.BibliotecaCommand.AdicionarJogo;
using FCG.Application.Commands.JogoCommand.CadastrarJogo;
using FCG.Application.Commands.JogoCommand.EditarJogo;
using FCG.Application.Commands.JogoCommand.ExcluirJogo;
using FCG.Application.Commands.UsuarioCommand.CadastrarUsuario;
using FCG.Application.Commands.UsuarioCommand.EditarUsuario;
using FCG.Application.Commands.UsuarioCommand.ExcluirUsuario;
using FCG.Application.Commands.UsuarioCommand.Login;
using FCG.Application.Interfaces.Queries;
using FCG.Application.Interfaces.Security;
using FCG.Core.Behaviors;
using FCG.Core.UnitOfWork;
using FCG.Infra;
using FCG.Infra.Queries;
using FCG.Infra.Security;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Query Services
builder.Services.AddScoped<IUsuarioQueryService, UsuarioQueryService>();
builder.Services.AddScoped<IJogoQueryService, JogoQueryService>();
builder.Services.AddScoped<IBibliotecaQueryService, BibliotecaQueryService>();
#endregion

#region MEDIATR
//Usuario
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CadastrarUsuarioHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CadastrarUsuarioValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EditarUsuarioHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(EditarUsuarioValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ExcluirUsuarioHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(ExcluirUsuarioValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(LoginValidator).Assembly);


//Jogo
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CadastrarJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CadastrarJogoValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EditarJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(EditarJogoValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ExcluirJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(ExcluirJogoValidator).Assembly);

//Biblioteca
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AdicionarJogoHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(AdicionarJogoValidator).Assembly);

#endregion

// Configuração do JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),

            ValidateIssuer = false,
            ValidateAudience = false,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FcgDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
