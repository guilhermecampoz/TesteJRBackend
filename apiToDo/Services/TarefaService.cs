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

            return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
        }

        public Result<Tarefa> ObterTarefa(int id)
        {
            var tarefa = _data.Tarefas.FirstOrDefault(x => x.Id == id);
            if (tarefa == null)
                return Result<Tarefa>.Falha(Erro.NotFound, new List<string> { "Não foi encontrado tarefa com o Id informado." });

            return Result<Tarefa>.Sucesso(tarefa);
        }

        public Result<List<Tarefa>> InserirTarefa(TarefaDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.Titulo))
            {
                return Result<List<Tarefa>>.Falha(Erro.Validation, new List<string> { "O nome da tarefa não pode ser vazio." });
            }

            int id = _data.Count;
            Tarefa tarefa = new Tarefa();
            tarefa.Titulo = request.Titulo;
            tarefa.Id = id;
            _data.Tarefas.Add(tarefa);

            return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
        }

        // recebe via parâmetro o id da tarefa informada na query
        public Result<List<Tarefa>> DeletarTarefa(int id)
        {
            // pesquisa no "banco" se há alguma tarefa com o Id informado na query
            var tarefa = _data.Tarefas.FirstOrDefault(x => x.Id == id);
            // Valida se não encontrou
            if (tarefa == null)
                // quando não encontra retorna falha do result pattern com tipo de erro NotFound para poder usar o status code correto na controller
                return Result<List<Tarefa>>.Falha(Erro.NotFound, new List<string> { "Não foi encontrada uma tarefa com o Id informado." });
            // se encontrar remove a tarefa via referência
            _data.Tarefas.Remove(tarefa);
            // retorna sucesso com a lista de tarefas atualizadas em memória da aplicação que foi configurada usando singleton na injeção de dependências
            return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
        }

        public Result<List<Tarefa>> AtualizarTarefa(int id, TarefaDTO request)
        {

            if (request == null || string.IsNullOrEmpty(request.Titulo))
            {
                return Result<List<Tarefa>>.Falha(Erro.Validation, new List<string> { "O nome da tarefa não pode ser vazio." });
            }

            var tarefa = _data.Tarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
                return Result<List<Tarefa>>.Falha(Erro.NotFound, new List<string> { "Não foi encontrada uma tarefa com o Id informado." });

            tarefa.Titulo = request.Titulo;

            return Result<List<Tarefa>>.Sucesso(_data.Tarefas);
        }
    }
}
