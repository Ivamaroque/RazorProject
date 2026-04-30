using RazorProject.Api.DTOs;

namespace RazorProject.Api.Services.Interfaces;

public interface ICategoriaService
{
    Task<List<CategoriaDto>> ListarAsync();
    Task<int> CriarAsync(CategoriaDto dto);
    Task<bool> AtualizarAsync(int id, CategoriaDto dto);
    Task<bool> RemoverAsync(int id);
}
