using RazorProject.Api.DTOs;
using RazorProject.Api.Models;
using RazorProject.Api.Repositories.Interfaces;
using RazorProject.Api.Services.Interfaces;

namespace RazorProject.Api.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<CategoriaDto>> ListarAsync()
    {
        var categorias = await _categoriaRepository.ListarAsync();
        return categorias
            .Select(c => new CategoriaDto { Id = c.Id, Nome = c.Nome })
            .ToList();
    }

    public async Task<int> CriarAsync(CategoriaDto dto)
    {
        var categoria = new Categoria { Nome = dto.Nome };
        await _categoriaRepository.AdicionarAsync(categoria);
        return categoria.Id;
    }

    public async Task<bool> AtualizarAsync(int id, CategoriaDto dto)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(id);
        if (categoria == null)
        {
            return false;
        }

        categoria.Nome = dto.Nome;
        await _categoriaRepository.AtualizarAsync(categoria);
        return true;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(id);
        if (categoria == null)
        {
            return false;
        }

        await _categoriaRepository.RemoverAsync(categoria);
        return true;
    }
}
