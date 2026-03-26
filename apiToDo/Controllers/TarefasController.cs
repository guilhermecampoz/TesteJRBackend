using apiToDo.Common;
﻿using apiToDo.DTO;
using apiToDo.Models;
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
