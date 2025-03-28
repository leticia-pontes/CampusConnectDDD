using Microsoft.EntityFrameworkCore;
using CampusConnectDDD.Domain.Entities;

namespace CampusConnectDDD.Infrastructure.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=CampusConnectDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Postagem> Postagens { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    
    public DbSet<Comentario> Comentarios { get; set; }
}