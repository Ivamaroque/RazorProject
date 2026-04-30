using Microsoft.AspNetCore.Mvc;
using RazorProject.Api.DTOs;
using RazorProject.Api.Services.Interfaces;

namespace RazorProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoriaDto>>> Get()
    {
        var categorias = await _categoriaService.ListarAsync();
        return Ok(categorias);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var id = await _categoriaService.CriarAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var updated = await _categoriaService.AtualizarAsync(id, dto);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var removed = await _categoriaService.RemoverAsync(id);
        if (!removed)
        {
            return NotFound();
        }

        return NoContent();
    }
}
