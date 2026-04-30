using Microsoft.EntityFrameworkCore;
using RazorProject.Api.Data;
using RazorProject.Api.Models;
using RazorProject.Api.Models.Enums;
using RazorProject.Api.Repositories.Interfaces;

namespace RazorProject.Api.Repositories;

public class ChamadoRepository : IChamadoRepository
{
    private readonly AppDbContext _context;

    public ChamadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Chamado>> ListarAsync()
    {
        return await _context.Chamados
            .Include(c => c.Categoria)
            .Where(c => c.Ativo)
            .OrderByDescending(c => c.Prioridade == Prioridade.Urgente)
            .ThenByDescending(c => c.DataAbertura)
            .ToListAsync();
    }

    public async Task<Chamado?> ObterPorIdAsync(int id)
    {
        return await _context.Chamados
            .Include(c => c.Categoria)
            .FirstOrDefaultAsync(c => c.Id == id && c.Ativo);
    }

    public async Task AdicionarAsync(Chamado chamado)
    {
        _context.Chamados.Add(chamado);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Chamado chamado)
    {
        _context.Chamados.Update(chamado);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Chamado chamado)
    {
        chamado.Ativo = false;
        _context.Chamados.Update(chamado);
        await _context.SaveChangesAsync();
    }
}
