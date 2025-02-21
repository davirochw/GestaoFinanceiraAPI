using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DespesasController : ControllerBase
{
    private readonly IDespesaService _despesaService;
    private readonly IMapper _mapper;

    public DespesasController(IDespesaService despesaService, IMapper mapper)
    {
        _despesaService = despesaService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<DespesaDTO>> AdicionarDespesa(DespesaDTO despesaDTO)
    {
        var despesa = _mapper.Map<Despesa>(despesaDTO); // Mapear DTO para entidade
        var novaDespesa = await _despesaService.AdicionarDespesaAsync(despesa);
        var novaDespesaDTO = _mapper.Map<DespesaDTO>(novaDespesa); // Mapear entidade para DTO
        return CreatedAtAction(nameof(ObterDespesaPorId), new { id = novaDespesaDTO.Id }, novaDespesaDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DespesaDTO>> ObterDespesaPorId(int id, int usuarioId)
    {
        var despesa = await _despesaService.ObterDespesaPorIdAsync(id, usuarioId);
        if (despesa == null)
            return NotFound();

        var despesaDTO = _mapper.Map<DespesaDTO>(despesa); // Mapear entidade para DTO
        return Ok(despesaDTO);
    }
}