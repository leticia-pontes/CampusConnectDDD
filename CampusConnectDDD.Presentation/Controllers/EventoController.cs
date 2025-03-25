using CampusConnectDDD.Domain.Entities;
using CampusConnectDDD.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectDDD.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    [HttpPost]
    public IActionResult Post(Evento evento)
    {
        try
        {
            var eventoCriado = _eventoRepository.Adicionar(evento);
            return CreatedAtAction(nameof(GetById), new { id = eventoCriado.Id },
                eventoCriado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar evento: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var evento = _eventoRepository.ObterEventoPorId(id);
        if (evento == null) return NotFound();

        return Ok(evento);
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var eventos = _eventoRepository.Listar();
            if (eventos == null || !eventos.Any()) return NotFound();

            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar eventos: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Evento eventoAtualizado)
    {
        var evento = _eventoRepository.ObterEventoPorId(id);
        if (evento == null) return NotFound();
        
        evento.Nome = eventoAtualizado.Nome;
        evento.Local = eventoAtualizado.Local;
        evento.Descricao = eventoAtualizado.Descricao;
        evento.EventoAberto = eventoAtualizado.EventoAberto;
        evento.DataHora = eventoAtualizado.DataHora;
        
        _eventoRepository.Atualizar(id, eventoAtualizado);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var evento = _eventoRepository.ObterEventoPorId(id);
        if (evento == null) return NotFound();
        
        _eventoRepository.Deletar(id);
        return NoContent();
    }
}