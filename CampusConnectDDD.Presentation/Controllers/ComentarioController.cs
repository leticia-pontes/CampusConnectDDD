using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectDDD.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioController : ControllerBase
{
    private readonly IComentarioRepository _comentarioRepository;

    public ComentarioController(IComentarioRepository comentarioRepository)
    {
        _comentarioRepository = comentarioRepository;
    }

    [HttpPost]
    public IActionResult Post(Comentario comentario)
    {
        try
        {
            var comentarioPublicado = _comentarioRepository.Adicionar(comentario);
            return CreatedAtAction(nameof(GetById), new { id = comentarioPublicado.Id },
                comentarioPublicado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar comentário: {ex.Message}");
        }
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var comentario = _comentarioRepository.ObterComentarioPorId(id);
        if (comentario == null) return NotFound();

        return Ok(comentario);
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var comentarios = _comentarioRepository.Listar();
            if (comentarios == null || !comentarios.Any()) return NotFound();

            return Ok(comentarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar comentários: {ex.Message}");
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, Comentario comentarioAtualizado)
    {
        var comentario = _comentarioRepository.ObterComentarioPorId(id);
        if (comentario == null) return NotFound();

        comentario.Texto = comentarioAtualizado.Texto;
        comentario.DataCriacao = comentarioAtualizado.DataCriacao;
        comentario.UsuarioId = comentarioAtualizado.UsuarioId;
        comentario.PostagemId = comentarioAtualizado.PostagemId;
        
        _comentarioRepository.Atualizar(id, comentario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var comentario = _comentarioRepository.ObterComentarioPorId(id);
        if (comentario == null) return NotFound();
        
        _comentarioRepository.Remover(id);
        return NoContent();
    }
}