using System.ComponentModel.DataAnnotations;
using RazorProject.Api.Models.Enums;

namespace RazorProject.Api.DTOs;

public class ChamadoUpdateDto
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
    public Prioridade Prioridade { get; set; }

    [Required]
    public StatusChamado Status { get; set; }

    [StringLength(150)]
    public string? Responsavel { get; set; }
}
