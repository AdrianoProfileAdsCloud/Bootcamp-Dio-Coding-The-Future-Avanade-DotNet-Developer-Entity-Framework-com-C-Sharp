using System;
using System.Collections.Generic;
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
        private readonly AppDbContext _context ;
        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarColaborador(Colaborador colaborador)
        {
            if (colaborador.Projeto == "")
                return BadRequest(new { Erro = "A o Projeto deve ser informado" });

            if(colaborador.InicioProjeto == DateTime.MinValue || colaborador.FimProjeto == DateTime.MinValue)   
            return BadRequest(new { Erro = "A data não pode ser vazia" }); 

            if(colaborador.FimProjeto <= colaborador.InicioProjeto)
            return BadRequest(new { Erro = "A data de Fim do Projeto não pode ser menor que a Data de Inicio de Projeto" }); 

            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
             _context.Add(colaborador);
             _context.SaveChanges();

            return CreatedAtAction(nameof(ObeterPorId), new { id = colaborador.Id }, colaborador);
        }

        [HttpGet("{id}")]
        public IActionResult ObeterPorId(int id)
        {
            var colaborador = _context.Colaborador.Find(id);
            if(colaborador == null)
         
            return NotFound();
            return Ok(colaborador);
         
      }

    }
}
        