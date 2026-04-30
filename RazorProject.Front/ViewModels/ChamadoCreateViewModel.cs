using System.ComponentModel.DataAnnotations;

namespace RazorProject.Front.ViewModels;

public class ChamadoCreateViewModel
{
    [Required]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [MinLength(10)]
    [StringLength(2000)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public int CategoriaId { get; set; }

    [Required]
    public int Prioridade { get; set; }

    [Required]
    [StringLength(150)]
    public string Solicitante { get; set; } = string.Empty;

    [StringLength(150)]
    public string? Responsavel { get; set; }

    public List<CategoriaViewModel> Categorias { get; set; } = new();
}
