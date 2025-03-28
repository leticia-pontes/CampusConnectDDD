namespace CampusConnectDDD.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string? Curso { get; set; }
    public List<int>? Seguidores { get; set; }
    public List<int>? Seguindo { get; set; }
    
    public Usuario()
    {
        Seguidores = new List<int>();
        Seguindo = new List<int>();
    }

    public void AdicionarSeguindo(int id)
    {
        if (!Seguindo.Contains(id)) Seguindo.Add(id);
    }
    
    public void RemoverSeguindo(int id)
    {
        if (Seguindo.Contains(id)) Seguindo.Remove(id);
    }
    
    public void AdicionarSeguidor(int id)
    {
        if (!Seguidores.Contains(id)) Seguidores.Add(id);
    }
    
    public void RemoverSeguidor(int id)
    {
        if (Seguidores.Contains(id)) Seguidores.Remove(id);
    }
}