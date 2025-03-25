using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Data;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectDDD.Infrastructure.Repositories;

public class PostagemRepository : IPostagemRepository
{
    private readonly AppDbContext _context;

    public PostagemRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Postagem Adicionar(Postagem postagem)
    {
        try
        {
            _context.Postagens.Add(postagem);
            _context.SaveChanges();
            return postagem;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao adicionar postagem: ", ex);
        }
    }

    public Postagem? ObterPostagemPorId(int id)
    {
        return _context.Postagens.FirstOrDefault(p => p.Id == id);
    }

    public List<Postagem> Listar()
    {
        return _context.Postagens.ToList();
    }

    public bool Atualizar(int id, Postagem postagem)
    {
        if (id != postagem.Id) return false;
        
        _context.Postagens.Update(postagem);
        _context.SaveChanges();
        return true;
    }

    public bool Deletar(int id)
    {
        if (id <= 0) return false;
        
        var postagem = _context.Postagens.Find(id);
        if (postagem == null) return false;
        
        _context.Postagens.Remove(postagem);
        _context.SaveChanges();
        return true;
    }
}