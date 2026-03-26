using apiToDo.Common;
using apiToDo.Data;
using apiToDo.DTO;
using apiToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Services
{
    public class TarefaService
    {
        private TarefaData _data;
        public TarefaService(TarefaData data)
        {
            _data = data;
        }

        public Result<List<Tarefa>> ListarTarefas()
        {
            try
            {
                return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<List<Tarefa>> InserirTarefa(TarefaDTO request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.DS_TAREFA))
                {
                    return Result<List<Tarefa>>.Falha(Erro.Validation, new List<string> { "O nome da tarefa não pode ser vazio." });
                }

                int id = _data.Count;
                Tarefa tarefa = new Tarefa();
                tarefa.DS_TAREFA = request.DS_TAREFA;
                tarefa.ID_TAREFA = id;
                _data.Tarefas.Add(tarefa);

                return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<List<Tarefa>> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                var tarefa = _data.Tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                if (tarefa == null)
                    return Result<List<Tarefa>>.Falha(Erro.NotFound, new List<string> { "Não foi encontrada uma tarefa com o Id informado." });

                _data.Tarefas.Remove(tarefa);

                return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
