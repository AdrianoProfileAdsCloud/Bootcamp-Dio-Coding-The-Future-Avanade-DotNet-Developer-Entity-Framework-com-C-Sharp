using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Context;
using ProjetoAPI.Models;


namespace ProjetoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public  IActionResult CadastrarColaborador(Colaborador colaborador)
        {
            if (colaborador.Projeto == "")
            {
                return BadRequest(new { Erro = "A o Projeto deve ser informado" });
            }
            if (colaborador.InicioProjeto == DateTime.MinValue || colaborador.FimProjeto == DateTime.MinValue)
            {
                return BadRequest(new { Erro = "A data não pode ser vazia" });
            }
            if (colaborador.FimProjeto <= colaborador.InicioProjeto)
            {
                return BadRequest(new { Erro = "A data de Fim do Projeto não pode ser menor que a Data de Inicio de Projeto" });
            }
            _context.Add(colaborador);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterColaboradorPorId), new { id = colaborador.Id }, colaborador);

        }

        [HttpGet("ObterColaboradorPorId/{id}")]
        public async Task<IActionResult> ObterColaboradorPorId(int id)
        {
            var colaborador = await _context.Colaborador
            .Where(c => c.Id == id)
            .Include(c => c.Tarefas)
            .Select(c => new
            {
                c.Id,
                c.Nome,
                c.Projeto,
                c.InicioProjeto,
                c.FimProjeto,
                Tarefas = c.Tarefas.Select(t => new
                {
                    t.Id,
                    t.Titulo,
                    t.Descricao,
                    t.Data,
                    t.Status
                }).ToList()
            })
            .FirstOrDefaultAsync();

            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }
    

    [HttpGet("ObterColaboradorPorNome/{nome}")]
    public async Task<IActionResult> ObterColaboradorPorNome(string nome)
    {
        //Uma das forma de se fazer
        //var colaborador = _context.Colaborador.Where(x => x.Nome.Contains(nome));
        //Por questões de ser uma api a forma abaixo é muito mais perfomatica por assíncrono
        //Outras rotas também poderiam estar de forma assíncrono, vou deixar apenas algumas desta forma 
        //para demostrar o que aprendi em minha busca por mais informações a respeito!

            var colaborador = await _context.Colaborador
            .Where(c => c.Nome == nome)
            .Include(c => c.Tarefas)
            .Select(c => new
            {
                c.Id,
                c.Nome,
                c.Projeto,
                c.InicioProjeto,
                c.FimProjeto,
                Tarefas = c.Tarefas.Select(t => new
                {
                    t.Id,
                    t.Titulo,
                    t.Descricao,
                    t.Data,
                    t.Status
                }).ToList()
            })
            .FirstOrDefaultAsync();

            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }
    
     [HttpPut("AtualizarColaborador/{id}")]
    public IActionResult AtualizarColaborador(int id, Colaborador colaborador)
    {
        var colaboradorBD = _context.Colaborador.Find(id);
        if (colaboradorBD != null)
        {
            colaboradorBD.Nome = colaborador.Nome;
            colaboradorBD.Projeto = colaborador.Projeto;
            colaboradorBD.InicioProjeto = colaborador.InicioProjeto;
            colaborador.FimProjeto = colaborador.FimProjeto;

            _context.Colaborador.Update(colaboradorBD);
            _context.SaveChanges();

            return Ok(colaboradorBD);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("DeletarColaborador/{id}")]
    public IActionResult DeletarColaborador(int id)
    {
        var colaboradorBD = _context.Colaborador.Find(id);
        if (colaboradorBD != null)
        {
            _context.Colaborador.Remove(colaboradorBD);
            _context.SaveChanges();
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("ObterTodosColaboradores")]
    public async Task<IActionResult> ObterTodosColaboradores()
    {
        var colaboradores = await _context.BuscarTodosColaboradores();
        return Ok(colaboradores);
    }
}
}
