using CampusConnectDDD.Domain.Entities;

namespace CampusConnectDDD.Infrastructure.Interfaces;

public interface IUsuarioRepository
{
    Usuario Adicionar(Usuario usuario);
    Usuario? ObterUsuarioPorId(int id);
    List<Usuario> Listar();
    bool Atualizar(int id, Usuario usuario);
    bool Deletar(int id);
}