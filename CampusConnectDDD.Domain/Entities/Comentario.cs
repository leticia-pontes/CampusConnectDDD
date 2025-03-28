namespace CampusConnectDDD.Domain.Entities;

public class Comentario
{
    public int Id { get; set; }
    
    public string Texto { get; set; }
    
    public DateTime DataCriacao { get; set; }

    public int UsuarioId { get; set; }
}
