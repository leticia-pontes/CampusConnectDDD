using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Data;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectDDD.Infrastructure.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public Evento Adicionar(Evento evento)
    {
        try
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
            return evento;
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException != null)
            {
                throw new Exception("Erro ao salvar no banco: " + ex.InnerException.Message);
            }
            throw;
        }
    }

    public Evento? ObterEventoPorId(int id)
    {
        return _context.Eventos.FirstOrDefault(e => e.Id == id);
    }

    public List<Evento> Listar()
    {
        return _context.Eventos.ToList();
    }

    public bool Atualizar(int id, Evento evento)
    {
        if (id != evento.Id) return false;
        
        _context.Eventos.Update(evento);
        _context.SaveChanges();
        return true;
    }

    public bool Deletar(int id)
    {
        if (id <= 0) return false;
        
        var evento = _context.Eventos.FirstOrDefault(e => e.Id == id);
        if (evento == null) return false;
        
        _context.Eventos.Remove(evento);
        _context.SaveChanges();
        return true;
    }
}