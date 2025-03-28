using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Data;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectDDD.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Usuario Adicionar(Usuario usuario)
    {
        try
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao adicionar usuário: ", ex);
        }
    }

    public Usuario? ObterUsuarioPorId(int id)
    {
        return _context.Usuarios
            .FirstOrDefault(u => u.Id == id);
    }

    public List<Usuario> Listar()
    {
        return _context.Usuarios
            .ToList();
    }

    public bool Atualizar(int id, Usuario usuario)
    {
        if (id != usuario.Id) return false;
        
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
        return true;
    }

    public bool Deletar(int id)
    {
        if (id <= 0) return false;
        
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) return false;
        
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return true;
    }
}