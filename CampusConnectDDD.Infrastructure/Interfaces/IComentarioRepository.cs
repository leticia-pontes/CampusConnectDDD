using CampusConnectDDD.Domain.Entities;

namespace CampusConnectDDD.Infrastructure.Interfaces;

public interface IComentarioRepository
{
    Comentario Adicionar(Comentario comentario);
    Comentario? ObterComentarioPorId(int id);
    List<Comentario> Listar();
    bool Atualizar(int id, Comentario comentario);
    bool Remover(int id);
}