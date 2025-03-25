using CampusConnectDDD.Domain.Entities;

namespace CampusConnectDDD.Infrastructure.Interfaces;

public interface IEventoRepository
{
    Evento Adicionar(Evento evento);
    Evento? ObterEventoPorId(int id);
    List<Evento> Listar();
    bool Atualizar(int id, Evento evento);
    bool Deletar(int id);
}