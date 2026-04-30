using RazorProject.Api.Models.Enums;

namespace RazorProject.Api.Models;

public class Chamado
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public Prioridade Prioridade { get; set; }
    public StatusChamado Status { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public string Solicitante { get; set; } = string.Empty;
    public string? Responsavel { get; set; }
    public bool Ativo { get; set; } = true;
}
