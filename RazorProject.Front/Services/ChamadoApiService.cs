using System.Net.Http.Json;
using RazorProject.Front.Services.Interfaces;
using RazorProject.Front.ViewModels;

namespace RazorProject.Front.Services;

public class ChamadoApiService : IChamadoApiService
{
    private readonly HttpClient _httpClient;

    public ChamadoApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ChamadoListViewModel>> ListarAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ChamadoListViewModel>>("api/chamados");
        return result ?? new List<ChamadoListViewModel>();
    }

    public async Task<ChamadoDetailsViewModel?> ObterAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ChamadoDetailsViewModel>($"api/chamados/{id}");
    }

    public async Task<bool> CriarAsync(ChamadoCreateViewModel viewModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/chamados", viewModel);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> AtualizarAsync(ChamadoEditViewModel viewModel)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/chamados/{viewModel.Id}", viewModel);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/chamados/{id}");
        return response.IsSuccessStatusCode;
    }
}
