using RazorProject.Api.Models;

namespace RazorProject.Api.Repositories.Interfaces;

public interface IChamadoRepository
{
    Task<List<Chamado>> ListarAsync();
    Task<Chamado?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Chamado chamado);
    Task AtualizarAsync(Chamado chamado);
    Task RemoverAsync(Chamado chamado);
}
