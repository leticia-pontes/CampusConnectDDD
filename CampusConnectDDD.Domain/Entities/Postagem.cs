namespace CampusConnectDDD.Domain.Entities;

public class Postagem
{
    public int Id { get; set; }
    public int AutorId { get; set; }
    public string Conteudo { get; set; }
    public int Curtidas { get; set; }
    public string Comentarios { get; set; }
    public DateTime DataHora { get; set; }
}