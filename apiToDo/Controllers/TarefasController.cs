using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var tarefas = new Tarefas();
                return StatusCode(200, tarefas.lstTarefas());
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] TarefaDTO Request)
        {
            try
            {

                return StatusCode(200);


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

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
