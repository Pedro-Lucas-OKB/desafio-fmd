namespace FMDLab.Models;

public class Participante
{
    public Guid Id { get; init; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public Guid PalestraId { get; set; }
    public Palestra Palestra { get; set; } = null!;
}