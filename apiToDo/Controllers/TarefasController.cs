using apiToDo.Common;
using apiToDo.DTO;
using apiToDo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private TarefaService _service;
        public TarefasController(TarefaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var result = _service.ListarTarefas();
                return StatusCode(200, result.Valor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var result = _service.ObterTarefa(id);

                if (result.ehSucesso)
                    return StatusCode(200, result.Valor);

                return result.TipoErro switch
                {
                    Erro.NotFound => StatusCode(404, result.Erros)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] TarefaDTO Request)
        {
            try
            {
                var result = _service.InserirTarefa(Request);
                if(result.ehSucesso)
                    return StatusCode(200, result.Valor);

                return result.TipoErro switch
                {
                    Erro.Validation => StatusCode(400, result.Erros),
                    _ => StatusCode(500, result.Erros)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int ID_TAREFA)
        {
            try
            {
                var result = _service.DeletarTarefa(ID_TAREFA);
                if(result.ehSucesso)
                    return StatusCode(200, result.Valor);

                return result.TipoErro switch
                {
                    Erro.NotFound => StatusCode(404, result.Erros),
                    _ => StatusCode(500, result.Erros)            
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TarefaDTO request)
        {
            try
            {
                var result = _service.AtualizarTarefa(id, request);

                if (result.ehSucesso)
                    return StatusCode(200, result.Valor);

                return result.TipoErro switch
                {
                    Erro.NotFound => StatusCode(404, result.Erros),
                    Erro.Validation => StatusCode(400, result.Erros),
                    _ => StatusCode(500, result.Erros)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
