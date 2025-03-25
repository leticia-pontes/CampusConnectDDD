namespace CampusConnectDDD.Domain.Entities;

public class Postagem
{
    public int Id { get; set; }
    public Usuario Autor { get; set; }
    public string Conteudo { get; set; }
    public int Curtidas { get; set; }
    public string Comentarios { get; set; }
    public DateTime DataHora { get; set; }
}