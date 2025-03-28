using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectDDD.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult Post(Usuario usuario)
    {
        try
        {
            var usuarioCriado = _usuarioRepository.Adicionar(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuarioCriado.Id },
                usuarioCriado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar usuário: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var usuario = _usuarioRepository.ObterUsuarioPorId(id);
        if (usuario == null) return NotFound();

        return Ok(usuario);
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var usuarios = _usuarioRepository.Listar();
            if (usuarios == null || !usuarios.Any()) return NotFound();

            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar usuários: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Usuario usuarioAtualizado)
    {
        var usuario = _usuarioRepository.ObterUsuarioPorId(id);
        if (usuario == null) return NotFound();
        
        usuario.Nome = usuarioAtualizado.Nome;
        usuario.Email = usuarioAtualizado.Email;
        usuario.Senha = usuarioAtualizado.Senha;
        usuario.Curso = usuarioAtualizado.Curso;
        usuario.Seguidores = usuarioAtualizado.Seguidores;
        usuario.Seguindo = usuarioAtualizado.Seguindo;
        
        _usuarioRepository.Atualizar(id, usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = _usuarioRepository.ObterUsuarioPorId(id);
        if (usuario == null) return NotFound();
        
        _usuarioRepository.Deletar(id);
        return NoContent();
    }
}