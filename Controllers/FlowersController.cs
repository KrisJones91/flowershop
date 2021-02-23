using System;
using System.Collections.Generic;
using flowershop.Models;
using flowershop.Service;
using Microsoft.AspNetCore.Mvc;

namespace flowershop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowersController : ControllerBase
    {
        private readonly FlowersService _service;

        public FlowersController(FlowersService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Flower>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Flower> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Flower> Create([FromBody] Flower newFlower)
        {
            try
            {
                return Ok(_service.Create(newFlower));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Flower> Edit([FromBody] Flower editFlower, int id)
        {
            try
            {
                editFlower.Id = id;
                return Ok(_service.Edit(editFlower));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Flower> Delete(int id)
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