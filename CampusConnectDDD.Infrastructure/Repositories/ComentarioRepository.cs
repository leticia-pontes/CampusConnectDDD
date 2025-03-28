using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Data;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectDDD.Infrastructure.Repositories;

public class ComentarioRepository : IComentarioRepository
{
    private readonly AppDbContext _context;

    public ComentarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public Comentario Adicionar(Comentario comentario)
    {
        try
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
            return comentario;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Erro ao adicionar comentario", ex);
        }
    }

    public Comentario? ObterComentarioPorId(int id)
    {
        return _context.Comentarios.FirstOrDefault(c => c.Id == id);
    }

    public List<Comentario> Listar()
    {
        return _context.Comentarios.ToList();
    }

    public bool Atualizar(int id, Comentario comentario)
    {
        if (id != comentario.Id) return false;
        
        _context.Comentarios.Update(comentario);
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        if (id <= 0) return false;
        
        var comentario = ObterComentarioPorId(id);
        if (comentario == null) return false;
        
        _context.Comentarios.Remove(comentario);
        _context.SaveChanges();
        return true;
    }
}