namespace CampusConnectDDD.Domain.Services;

using CampusConnectDDD.Domain.Entities;

public interface IEventoService
{
    bool EventoAberto(Evento evento);
    bool EventoAtingiuLimiteDeParticipantes(Evento evento);
    bool UsuarioEhParticipanteDoEvento(Evento evento, Usuario usuario);
    void AdicionarParticipante(Evento evento, Usuario usuario);
    void RemoverParticipante(Evento evento, Usuario usuario);
}

public class EventoService : IEventoService
{
    public bool EventoAberto(Evento evento)
    {
        return evento.EventoAberto;
    }

    public bool EventoAtingiuLimiteDeParticipantes(Evento evento)
    {
        return evento.Participantes.Count >= 50;
    }

    public bool UsuarioEhParticipanteDoEvento(Evento evento, Usuario usuario)
    {
        return evento.Participantes.FirstOrDefault(p => p.Id == usuario.Id) != null;
    }

    public void AdicionarParticipante(Evento evento, Usuario usuario)
    {
        if (!EventoAberto(evento))
        {
            throw new InvalidOperationException("O evento não está aberto para participação.");
        }

        if (EventoAtingiuLimiteDeParticipantes(evento))
        {
            throw new InvalidOperationException("O evento atingiu o limite de participantes.");
        }

        if (UsuarioEhParticipanteDoEvento(evento, usuario))
        {
            throw new InvalidOperationException("O usuário já é um participante deste evento.");
        }

        evento.Participantes.Add(usuario);
    }

    public void RemoverParticipante(Evento evento, Usuario usuario)
    {
        if (!UsuarioEhParticipanteDoEvento(evento, usuario))
        {
            throw new InvalidOperationException("O usuário não é um participante deste evento.");
        }
        
        evento.Participantes.Remove(usuario);
    }
}