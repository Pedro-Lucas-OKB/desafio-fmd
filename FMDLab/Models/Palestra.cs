namespace FMDLab.Models;

public class Palestra
{
    public Guid Id { get; init; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }

    public List<Participante> Participantes { get; set; } = null!;
}