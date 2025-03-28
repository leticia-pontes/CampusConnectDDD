using CampusConnectDDD.Infrastructure.Data;
using CampusConnectDDD.Infrastructure.Interfaces;
using CampusConnectDDD.Infrastructure.Repositories;

namespace CampusConnectDDD.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<AppDbContext>();

        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
        builder.Services.AddScoped<IEventoRepository, EventoRepository>();
        builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
        
        // Add services to the container.
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
    }
}