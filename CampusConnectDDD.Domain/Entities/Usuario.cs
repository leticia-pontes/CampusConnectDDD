namespace CampusConnectDDD.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Curso { get; set; }
    public List<Usuario> Seguidores { get; set; }
    public List<Usuario> Seguindo { get; set; }
}