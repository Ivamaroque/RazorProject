using RazorProject.Api.DTOs;
using RazorProject.Api.Models;
using RazorProject.Api.Models.Enums;
using RazorProject.Api.Repositories.Interfaces;
using RazorProject.Api.Services.Interfaces;

namespace RazorProject.Api.Services;

public class ChamadoService : IChamadoService
{
    private readonly IChamadoRepository _chamadoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ChamadoService(IChamadoRepository chamadoRepository, ICategoriaRepository categoriaRepository)
    {
        _chamadoRepository = chamadoRepository;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<ChamadoListDto>> ListarAsync()
    {
        var chamados = await _chamadoRepository.ListarAsync();

        return chamados
            .Select(MapToListDto)
            .ToList();
    }

    public async Task<ChamadoDetailsDto?> ObterAsync(int id)
    {
        var chamado = await _chamadoRepository.ObterPorIdAsync(id);
        return chamado == null ? null : MapToDetailsDto(chamado);
    }

    public async Task<int> CriarAsync(ChamadoCreateDto dto)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(dto.CategoriaId);
        if (categoria == null)
        {
            throw new InvalidOperationException("Categoria nao encontrada.");
        }

        var chamado = new Chamado
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            CategoriaId = dto.CategoriaId,
            Prioridade = dto.Prioridade,
            Status = StatusChamado.Aberto,
            DataAbertura = DateTime.Now,
            Solicitante = dto.Solicitante,
            Responsavel = dto.Responsavel
        };

        await _chamadoRepository.AdicionarAsync(chamado);
        return chamado.Id;
    }

    public async Task<bool> AtualizarAsync(int id, ChamadoUpdateDto dto)
    {
        var chamado = await _chamadoRepository.ObterPorIdAsync(id);
        if (chamado == null)
        {
            return false;
        }

        if (chamado.Status == StatusChamado.Finalizado && dto.Status != StatusChamado.Reaberto)
        {
            throw new InvalidOperationException("Chamado finalizado so pode ser reaberto.");
        }

        if (chamado.Status == StatusChamado.Cancelado && dto.Status == StatusChamado.Finalizado)
        {
            throw new InvalidOperationException("Chamado cancelado nao pode ser finalizado.");
        }

        chamado.Titulo = dto.Titulo;
        chamado.Descricao = dto.Descricao;
        chamado.CategoriaId = dto.CategoriaId;
        chamado.Prioridade = dto.Prioridade;
        chamado.Status = dto.Status;
        chamado.Responsavel = dto.Responsavel;

        if (dto.Status == StatusChamado.Finalizado)
        {
            chamado.DataFinalizacao = DateTime.Now;
        }
        else
        {
            chamado.DataFinalizacao = null;
        }

        await _chamadoRepository.AtualizarAsync(chamado);
        return true;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var chamado = await _chamadoRepository.ObterPorIdAsync(id);
        if (chamado == null)
        {
            return false;
        }

        await _chamadoRepository.RemoverAsync(chamado);
        return true;
    }

    private static ChamadoListDto MapToListDto(Chamado chamado)
    {
        return new ChamadoListDto
        {
            Id = chamado.Id,
            Titulo = chamado.Titulo,
            Categoria = chamado.Categoria?.Nome ?? string.Empty,
            Prioridade = chamado.Prioridade.ToString(),
            Status = chamado.Status.ToString(),
            DataAbertura = chamado.DataAbertura
        };
    }

    private static ChamadoDetailsDto MapToDetailsDto(Chamado chamado)
    {
        return new ChamadoDetailsDto
        {
            Id = chamado.Id,
            Titulo = chamado.Titulo,
            Descricao = chamado.Descricao,
            Categoria = chamado.Categoria?.Nome ?? string.Empty,
            CategoriaId = chamado.CategoriaId,
            Prioridade = chamado.Prioridade.ToString(),
            PrioridadeValue = (int)chamado.Prioridade,
            Status = chamado.Status.ToString(),
            StatusValue = (int)chamado.Status,
            DataAbertura = chamado.DataAbertura,
            DataFinalizacao = chamado.DataFinalizacao,
            Solicitante = chamado.Solicitante,
            Responsavel = chamado.Responsavel
        };
    }
}
