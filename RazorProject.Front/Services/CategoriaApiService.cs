using System.Net.Http.Json;
using RazorProject.Front.Services.Interfaces;
using RazorProject.Front.ViewModels;

namespace RazorProject.Front.Services;

public class CategoriaApiService : ICategoriaApiService
{
    private readonly HttpClient _httpClient;

    public CategoriaApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CategoriaViewModel>> ListarAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<CategoriaViewModel>>("api/categorias");
        return result ?? new List<CategoriaViewModel>();
    }
}
