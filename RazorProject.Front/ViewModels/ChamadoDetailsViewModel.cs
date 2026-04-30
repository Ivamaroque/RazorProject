namespace RazorProject.Front.ViewModels;

public class ChamadoDetailsViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public string Prioridade { get; set; } = string.Empty;
    public int PrioridadeValue { get; set; }
    public string Status { get; set; } = string.Empty;
    public int StatusValue { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public string Solicitante { get; set; } = string.Empty;
    public string? Responsavel { get; set; }
}
