using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Data
{
    public class TarefaData
    {
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>
        {
            new Tarefa
            {
                Id = 1,
                Titulo = "Fazer Compras"
            },
            new Tarefa
            {
                Id = 2,
                Titulo = "Fazer Atividade Faculdade"
            },
            new Tarefa
            {
                Id = 3,
                Titulo = "Subir Projeto de Teste no GitHub"
            }
        };

        public int Count => Tarefas.Count + 1;
    }
}
