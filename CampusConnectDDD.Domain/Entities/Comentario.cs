namespace CampusConnectDDD.Domain.Entities;

public class Comentario
{
    public int Id { get; set; }
    
    public string Texto { get; set; }
    
    public DateTime DataCriacao { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int PostagemId { get; set; }
    public Postagem Postagem { get; set; }
}
