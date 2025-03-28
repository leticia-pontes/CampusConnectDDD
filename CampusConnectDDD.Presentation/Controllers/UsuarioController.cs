using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

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

    /// <summary>
    /// Cria um usuário.
    /// </summary>
    /// <param name="usuario">Objeto do tipo 'Usuario' a ser inserido no banco</param>
    /// <returns>Retorna um status de sucesso ou uma exceção de erro.</returns>
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

    [HttpPost("{id}/seguir/{idSeguindo}")]
    public IActionResult Follow(int id, int idSeguindo)
    {
        var usuario = _usuarioRepository.ObterUsuarioPorId(id);
        var seguindo = _usuarioRepository.ObterUsuarioPorId(idSeguindo);
        
        if (usuario == null || seguindo == null) return NotFound("Usuário não encontrado.");
        if (usuario.Seguindo.Contains(idSeguindo)) return BadRequest("Você já segue este usuário.");
        
        usuario.AdicionarSeguindo(idSeguindo);
        seguindo.AdicionarSeguidor(id);

        _usuarioRepository.Atualizar(id, usuario);
        _usuarioRepository.Atualizar(idSeguindo, seguindo);
        
        return Ok("Agora você está seguindo este usuário.");
    }
    
    [HttpPost("{id}/deixarDeSeguir/{idSeguindo}")]
    public IActionResult Unfollow(int id, int idSeguindo)
    {
        var usuario = _usuarioRepository.ObterUsuarioPorId(id);
        var seguindo = _usuarioRepository.ObterUsuarioPorId(idSeguindo);
        
        if (usuario == null || seguindo == null) return NotFound("Usuário não encontrado.");
        if (!usuario.Seguindo.Contains(idSeguindo)) return BadRequest("Você não segue este usuário.");
        
        usuario.RemoverSeguindo(idSeguindo);
        seguindo.RemoverSeguidor(id);

        _usuarioRepository.Atualizar(id, usuario);
        _usuarioRepository.Atualizar(idSeguindo, seguindo);
        
        return Ok("Você deixou de seguir este usuário.");
    }
    
    [HttpPost("{id}/removerSeguidor/{idSeguidor}")]
    public IActionResult RemoveFollowe(int id, int idSeguidor)
    {
        var usuario = _usuarioRepository.ObterUsuarioPorId(id);
        var seguidor = _usuarioRepository.ObterUsuarioPorId(idSeguidor);
        
        if (usuario == null || seguidor == null) return NotFound("Usuário não encontrado.");
        if (!usuario.Seguidores.Contains(idSeguidor)) return BadRequest("Este usuário não te segue.");
        
        usuario.RemoverSeguidor(idSeguidor);
        seguidor.RemoverSeguindo(id);

        _usuarioRepository.Atualizar(id, usuario);
        _usuarioRepository.Atualizar(idSeguidor, seguidor);
        
        return Ok("Você removeu este usuário dos seus seguidores.");
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