using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Context;
using ProjetoAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefaController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("ObterTarefaPorId/{id}")]
        public IActionResult ObterTarefaPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa != null)
            {
                return Ok(tarefa);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("AtribuirTarefaAoColaborador")]
        public async Task<IActionResult> AtribuirTarefaAoColaborador(Tarefa tarefa)
        {
            if (tarefa == null || string.IsNullOrEmpty(tarefa.Titulo))
            {
                return BadRequest(new { Erro = "Dados inválidos para a tarefa" });
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Tarefas)
                .FirstOrDefaultAsync(c => c.Id == tarefa.ColaboradorId);

            if (colaborador == null)
            {
                return NotFound(new { Erro = "Colaborador não encontrado" });
            }

            colaborador.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.Id }, tarefa);
        }



        [HttpGet("ObterTodasTarefas")]
        public async Task<IActionResult> ObterTodasTarefas()
        {
            var tarefas = await _context.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorTitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo == titulo);
            if (tarefa != null)
            {
                return Ok(tarefa);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ObterTarefaPorData/{data}")]
        public IActionResult ObterTarefaPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            if (tarefa != null)
            {
                return Ok(tarefa);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("ObterTarefaPorStatus/{status}")]
        public IActionResult ObterTarefaPorStatus(EnumStatusTarefa status)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            if (tarefa != null)
            {
                return Ok(tarefa);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("AtualizarStatusTarefa/{id}")]
        public IActionResult AtualizarStatusTarefa(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            
            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;
            tarefaBanco.ColaboradorId = tarefa.ColaboradorId;
            tarefaBanco.Colaborador = tarefa.Colaborador;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefa);
        }

        [HttpDelete("DeletarTarefa/{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
