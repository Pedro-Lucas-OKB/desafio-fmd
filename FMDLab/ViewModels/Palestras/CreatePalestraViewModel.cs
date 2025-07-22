using System.ComponentModel.DataAnnotations;

namespace FMDLab.ViewModels.Palestras;

public class CreatePalestraViewModel
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; } = string.Empty;
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;
    [Required(ErrorMessage = "A data da palestra é obrigatória.")]
    public DateTime DataHora { get; set; }
}