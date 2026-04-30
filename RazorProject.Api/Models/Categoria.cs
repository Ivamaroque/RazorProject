using System.Collections.Generic;

namespace RazorProject.Api.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
}
