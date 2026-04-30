namespace RazorProject.Front.ViewModels;

public class ChamadoListViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
}
