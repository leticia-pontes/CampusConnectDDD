using CampusConnectDDD.Domain.Entities;

namespace CampusConnectDDD.Infrastructure.Interfaces;

public interface IPostagemRepository
{
    Postagem Adicionar(Postagem postagem);
    Postagem? ObterPostagemPorId(int id);
    List<Postagem> Listar();
    bool Atualizar(int id, Postagem postagem);
    bool Deletar(int id);
}