using System.ComponentModel.DataAnnotations;

namespace RazorProject.Api.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
}
