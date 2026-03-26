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
    }
}
