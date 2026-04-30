using RazorProject.Front.ViewModels;

namespace RazorProject.Front.Services.Interfaces;

public interface IChamadoApiService
{
    Task<List<ChamadoListViewModel>> ListarAsync();
    Task<ChamadoDetailsViewModel?> ObterAsync(int id);
    Task<bool> CriarAsync(ChamadoCreateViewModel viewModel);
    Task<bool> AtualizarAsync(ChamadoEditViewModel viewModel);
    Task<bool> RemoverAsync(int id);
}
