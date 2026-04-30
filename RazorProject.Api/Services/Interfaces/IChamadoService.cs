using RazorProject.Api.DTOs;

namespace RazorProject.Api.Services.Interfaces;

public interface IChamadoService
{
    Task<List<ChamadoListDto>> ListarAsync();
    Task<ChamadoDetailsDto?> ObterAsync(int id);
    Task<int> CriarAsync(ChamadoCreateDto dto);
    Task<bool> AtualizarAsync(int id, ChamadoUpdateDto dto);
    Task<bool> RemoverAsync(int id);
}
