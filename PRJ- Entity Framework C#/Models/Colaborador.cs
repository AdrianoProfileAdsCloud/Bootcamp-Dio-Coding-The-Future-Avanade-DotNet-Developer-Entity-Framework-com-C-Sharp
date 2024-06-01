using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjetoAPI.Models
{
    public class Colaborador
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Projeto{get;set;}
        public DateTime InicioProjeto{get;set;}
        public DateTime FimProjeto{get;set;}

        public ICollection<Tarefa> Tarefas{get;set;}
    }
}