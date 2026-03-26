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
                ID_TAREFA = 1,
                DS_TAREFA = "Fazer Compras"
            },
            new Tarefa
            {
                ID_TAREFA = 2,
                DS_TAREFA = "Fazer Atividade Faculdade"
            },
            new Tarefa
            {
                ID_TAREFA = 3,
                DS_TAREFA = "Subir Projeto de Teste no GitHub"
            }
        };

        public int Count => Tarefas.Count + 1;
    }
}
