using Application.DTO_s;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1_Cliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService _ocorrenciaService;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OcorrenciaDto>>> GetAll()
        {
            var ocorrencias = await _ocorrenciaService.GetAllAsync();
            return Ok(ocorrencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OcorrenciaDto>> GetById(int id)
        {
            var ocorrencia = await _ocorrenciaService.GetByIdAsync(id);
            if (ocorrencia == null) return NotFound();
            return Ok(ocorrencia);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OcorrenciaDto dto)
        {
            await _ocorrenciaService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OcorrenciaDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _ocorrenciaService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ocorrenciaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
