using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectDDD.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostagemController : ControllerBase
{
    private readonly IPostagemRepository _postagemRepository;

    public PostagemController(IPostagemRepository postagemRepository)
    {
        _postagemRepository = postagemRepository;
    }

    [HttpPost]
    public IActionResult Post(Postagem postagem)
    {
        try
        {
            if (postagem.Autor != null)
            {
                // Adicionando valores padrão para os campos obrigatórios do Autor
                if (postagem.Autor.Curso == null) postagem.Autor.Curso = "";
                if (postagem.Autor.Email == null) postagem.Autor.Email = "";
                if (postagem.Autor.Senha == null) postagem.Autor.Senha = "";
                if (postagem.Autor.Seguindo == null) postagem.Autor.Seguindo = new List<int>();
                if (postagem.Autor.Seguidores == null) postagem.Autor.Seguidores = new List<int>();
            }

            var postagemCriada = _postagemRepository.Adicionar(postagem);
            return CreatedAtAction(nameof(GetById), new { id = postagemCriada.Id },
                postagemCriada);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar postagem: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var postagem = _postagemRepository.ObterPostagemPorId(id);
        if (postagem == null) return NotFound();

        var resposta = new
        {
            postagem.Id,
            Autor = new
            {
                postagem.Autor.Id,
                postagem.Autor.Nome
            },
            postagem.Conteudo,
            postagem.Curtidas,
            postagem.Comentarios,
            postagem.DataHora
        };

        return Ok(resposta);
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var postagens = _postagemRepository.Listar();
            if (postagens == null || !postagens.Any()) return NotFound();

            var resposta = postagens.Select(postagem => new
            {
                postagem.Id,
                Autor = new
                {
                    postagem.Autor.Id,
                    postagem.Autor.Nome
                },
                postagem.Conteudo,
                postagem.Curtidas,
                postagem.Comentarios,
                postagem.DataHora
            });

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar postagens: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Postagem postagemAtualizada)
    {
        var postagem = _postagemRepository.ObterPostagemPorId(id);
        if (postagem == null) return NotFound();
        
        postagem.Autor = postagemAtualizada.Autor;
        postagem.Conteudo = postagemAtualizada.Conteudo;
        postagem.Curtidas = postagemAtualizada.Curtidas;
        postagem.Comentarios = postagemAtualizada.Comentarios;
        postagem.DataHora = postagemAtualizada.DataHora;
        
        _postagemRepository.Atualizar(id, postagem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var postagem = _postagemRepository.ObterPostagemPorId(id);
        if (postagem == null) return NotFound();
        
        _postagemRepository.Deletar(id);
        return NoContent();
    }
}
