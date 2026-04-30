using Microsoft.AspNetCore.Mvc;
using RazorProject.Front.Services.Interfaces;
using RazorProject.Front.ViewModels;

namespace RazorProject.Front.Controllers;

public class ChamadosController : Controller
{
    private readonly IChamadoApiService _chamadoApiService;
    private readonly ICategoriaApiService _categoriaApiService;

    public ChamadosController(IChamadoApiService chamadoApiService, ICategoriaApiService categoriaApiService)
    {
        _chamadoApiService = chamadoApiService;
        _categoriaApiService = categoriaApiService;
    }

    public async Task<IActionResult> Index()
    {
        var chamados = await _chamadoApiService.ListarAsync();
        return View(chamados);
    }

    public async Task<IActionResult> Details(int id)
    {
        var chamado = await _chamadoApiService.ObterAsync(id);
        if (chamado == null)
        {
            return NotFound();
        }

        return View(chamado);
    }

    public async Task<IActionResult> Create()
    {
        var viewModel = new ChamadoCreateViewModel
        {
            Categorias = await _categoriaApiService.ListarAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ChamadoCreateViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categorias = await _categoriaApiService.ListarAsync();
            return View(viewModel);
        }

        var created = await _chamadoApiService.CriarAsync(viewModel);
        if (!created)
        {
            ModelState.AddModelError(string.Empty, "Nao foi possivel criar o chamado.");
            viewModel.Categorias = await _categoriaApiService.ListarAsync();
            return View(viewModel);
        }

        TempData["Success"] = "Chamado cadastrado com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var chamado = await _chamadoApiService.ObterAsync(id);
        if (chamado == null)
        {
            return NotFound();
        }

        var viewModel = new ChamadoEditViewModel
        {
            Id = chamado.Id,
            Titulo = chamado.Titulo,
            Descricao = chamado.Descricao,
            CategoriaId = chamado.CategoriaId,
            Prioridade = chamado.PrioridadeValue,
            Status = chamado.StatusValue,
            Responsavel = chamado.Responsavel,
            Categorias = await _categoriaApiService.ListarAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ChamadoEditViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categorias = await _categoriaApiService.ListarAsync();
            return View(viewModel);
        }

        var updated = await _chamadoApiService.AtualizarAsync(viewModel);
        if (!updated)
        {
            ModelState.AddModelError(string.Empty, "Nao foi possivel atualizar o chamado.");
            viewModel.Categorias = await _categoriaApiService.ListarAsync();
            return View(viewModel);
        }

        TempData["Success"] = "Chamado atualizado com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var chamado = await _chamadoApiService.ObterAsync(id);
        if (chamado == null)
        {
            return NotFound();
        }

        return View(chamado);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var removed = await _chamadoApiService.RemoverAsync(id);
        if (!removed)
        {
            return NotFound();
        }

        TempData["Success"] = "Chamado excluido com sucesso.";
        return RedirectToAction(nameof(Index));
    }
}
