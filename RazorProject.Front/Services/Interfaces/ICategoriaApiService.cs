using RazorProject.Front.ViewModels;

namespace RazorProject.Front.Services.Interfaces;

public interface ICategoriaApiService
{
    Task<List<CategoriaViewModel>> ListarAsync();
}
