using RazorProject.Api.Models;

namespace RazorProject.Api.Repositories.Interfaces;

public interface ICategoriaRepository
{
    Task<List<Categoria>> ListarAsync();
    Task<Categoria?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Categoria categoria);
    Task AtualizarAsync(Categoria categoria);
    Task RemoverAsync(Categoria categoria);
}
