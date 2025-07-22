using FMDLab.Models;

namespace FMDLab.ViewModels.Participantes;

public class ListParticipantesViewModel
{
    public Guid Id { get; init; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Guid PalestraId { get; set; }


    public static implicit operator ListParticipantesViewModel(Participante participante)
        => new ListParticipantesViewModel
        {
            Id = participante.Id,
            Nome = participante.Nome,
            Email = participante.Email,
            Telefone = participante.Telefone,
            PalestraId = participante.PalestraId
        };

    public static List<ListParticipantesViewModel> ConvertAll(List<Participante> participantes)
    {
        List<ListParticipantesViewModel> list = new();
        foreach (var participante in participantes)
        {
            list.Add(participante);
        }

        return list;
    }
}