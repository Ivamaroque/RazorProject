using Microsoft.AspNetCore.Mvc;
using RazorProject.Api.DTOs;
using RazorProject.Api.Services.Interfaces;

namespace RazorProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : ControllerBase
{
    private readonly IChamadoService _chamadoService;

    public ChamadosController(IChamadoService chamadoService)
    {
        _chamadoService = chamadoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ChamadoListDto>>> Get()
    {
        var chamados = await _chamadoService.ListarAsync();
        return Ok(chamados);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ChamadoDetailsDto>> GetById(int id)
    {
        var chamado = await _chamadoService.ObterAsync(id);
        if (chamado == null)
        {
            return NotFound();
        }

        return Ok(chamado);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ChamadoCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            var id = await _chamadoService.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ChamadoUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            var updated = await _chamadoService.AtualizarAsync(id, dto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var removed = await _chamadoService.RemoverAsync(id);
        if (!removed)
        {
            return NotFound();
        }

        return NoContent();
    }
}
