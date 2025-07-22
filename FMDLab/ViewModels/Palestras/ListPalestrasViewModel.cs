using FMDLab.ViewModels.Participantes;

namespace FMDLab.ViewModels.Palestras;

public class ListPalestrasViewModel
{
    public Guid Id { get; init; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }

    public List<ListParticipantesViewModel> Participantes { get; set; } = null!;
}