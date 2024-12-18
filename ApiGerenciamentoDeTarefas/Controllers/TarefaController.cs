using Microsoft.AspNetCore.Mvc;
using ApiGerenciamentoDeTarefas.Dtos;
using ApiGerenciamentoDeTarefas.Services;
using GerenciadorTarefas.Dtos;

namespace ApiGerenciamentoDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaReadDto>>> GetAll()
        {
            var tarefas = await _tarefaService.GetAllAsync();
            return Ok(tarefas);
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TarefaReadDto>> GetById(int id)
        {
            try
            {
                var tarefa = await _tarefaService.GetByIdAsync(id);
                if (tarefa == null)
                    return NotFound(new { Message = "Tarefa não encontrada." });

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao buscar tarefa.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Route("RegistrarTarefa")]
        public async Task<IActionResult> Create([FromBody] TarefaCreateDto tarefaCreateDto)
        {
         var tarefa = await _tarefaService.CreateAsync(tarefaCreateDto);
         if (tarefa == null)
         {
             return BadRequest(tarefa);
         }
         return Ok(tarefa);
             
        }
        
        /*public async Task<ActionResult<TarefaReadDto>> Create([FromBody] TarefaCreateDto tarefaDto)
        {
            try
            {
                if (tarefaDto == null)
                    return BadRequest(new { Message = "Dados inválidos para criação da tarefa." });

                var tarefaCriada = await _tarefaService.CreateAsync(tarefaDto);
                return CreatedAtAction(nameof(GetById), new { id = tarefaCriada.Id }, tarefaCriada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao criar tarefa.", Details = ex.Message });
            }
        }*/


        [HttpPost]
        [Route("AtualizarTarefa/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TarefaUpdateDto tarefaUpdateDto)
        {
            var updateStatus = await _tarefaService.UpdateAsync(id, tarefaUpdateDto);
            if (updateStatus == false)
            {
                return Ok("Não foi possível atualizar a tarefa.");
            }
            else
            {
                return Ok("Tarefa atualizada com sucesso."); 
            }
            
        }
        
        /*public async Task<IActionResult> Update(int id, [FromBody] TarefaUpdateDto tarefaDto)
        {
            try
            {
                await _tarefaService.UpdateAsync(id, tarefaDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Tarefa não encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao atualizar tarefa.", Details = ex.Message });
            }
        }*/

        
        [HttpPost]
        [Route("DeletarTarefa")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tarefaService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Tarefa não encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao deletar tarefa.", Details = ex.Message });
            }
        }
    }
}
