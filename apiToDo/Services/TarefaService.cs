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

        public Result<Tarefa> ObterTarefa(int id)
        {
            try
            {
                var tarefa = _data.Tarefas.FirstOrDefault(x => x.ID_TAREFA == id);
                if (tarefa == null)
                    return Result<Tarefa>.Falha(Erro.NotFound, new List<string> { "Não foi encontrado tarefa com o Id informado." });

                return Result<Tarefa>.Sucesso(tarefa);
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
        // recebe via parâmetro o id da tarefa informada na query
        public Result<List<Tarefa>> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // pesquisa no "banco" se há alguma tarefa com o Id informado na query
                var tarefa = _data.Tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                // Valida se não encontrou
                if (tarefa == null)
                    // quando não encontra retorna falha do result pattern com tipo de erro NotFound para poder usar o status code correto na controller
                    return Result<List<Tarefa>>.Falha(Erro.NotFound, new List<string> { "Não foi encontrada uma tarefa com o Id informado." });
                // se encontrar remove a tarefa via referência
                _data.Tarefas.Remove(tarefa);
                // retorna sucesso com a lista de tarefas atualizadas em memória da aplicação que foi configurada usando singleton na injeção de dependências
                return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<List<Tarefa>> AtualizarTarefa(int ID_TAREFA, TarefaDTO request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.DS_TAREFA))
                {
                    return Result<List<Tarefa>>.Falha(Erro.Validation, new List<string> { "O nome da tarefa não pode ser vazio." });
                }

                var tarefa = _data.Tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                if (tarefa == null)
                    return Result<List<Tarefa>>.Falha(Erro.NotFound, new List<string> { "Não foi encontrada uma tarefa com o Id informado." });

                tarefa.DS_TAREFA = request.DS_TAREFA;

                return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
