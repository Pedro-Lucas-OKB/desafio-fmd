using System.ComponentModel.DataAnnotations;

namespace FMDLab.ViewModels.Participantes;

public class UpdateParticipanteViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail é inválido.")]
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}