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
            var postagemCriado = _postagemRepository.Adicionar(postagem);
            return CreatedAtAction(nameof(GetById), new { id = postagemCriado.Id },
                postagemCriado);
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

        return Ok(postagem);
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var postagems = _postagemRepository.Listar();
            if (postagems == null || !postagems.Any()) return NotFound();

            return Ok(postagems);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar postagens: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Postagem postagemAtualizado)
    {
        var postagem = _postagemRepository.ObterPostagemPorId(id);
        if (postagem == null) return NotFound();
        
        postagem.Autor = postagemAtualizado.Autor;
        postagem.Conteudo = postagemAtualizado.Conteudo;
        postagem.Curtidas = postagemAtualizado.Curtidas;
        postagem.Comentarios = postagemAtualizado.Comentarios;
        postagem.DataHora = postagemAtualizado.DataHora;
        
        _postagemRepository.Atualizar(id, postagemAtualizado);
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