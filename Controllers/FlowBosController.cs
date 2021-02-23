using System;
using flowershop.Models;
using flowershop.Service;
using Microsoft.AspNetCore.Mvc;

namespace flowershop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowBosController : ControllerBase
    {
        private readonly FlowBosService _service;

        public FlowBosController(FlowBosService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<FlowBo> Post([FromBody] FlowBo newFb)
        {
            try
            {
                return Ok(_service.Create(newFb));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}