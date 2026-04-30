using Microsoft.EntityFrameworkCore;
using RazorProject.Api.Data;
using RazorProject.Api.Models;
using RazorProject.Api.Repositories.Interfaces;

namespace RazorProject.Api.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        return await _context.Categorias
            .OrderBy(c => c.Nome)
            .ToListAsync();
    }

    public async Task<Categoria?> ObterPorIdAsync(int id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AdicionarAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}
