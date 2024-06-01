using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using ProjetoAPI.Context;
using ProjetoAPI.Models;

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

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
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

        [HttpPost]
        public async Task<IActionResult> Criar(Tarefa tarefa)
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

            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            var tarefas = await _context.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorTitulo")]
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

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
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

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
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

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
             var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null){
                return NotFound();
            }

            if (tarefa.Data == DateTime.MinValue)
            {
                 return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            }
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

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
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
