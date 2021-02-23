using System;
using System.Collections.Generic;
using flowershop.Service;
using flowershop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boquetshop.Controllers
{
    public class BoquetsController : ControllerBase
    {
        private readonly BoquetsService _service;

        public BoquetsController(BoquetsService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Boquet>> GetAll()
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
        public ActionResult<Boquet> GetById(int id)
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
        public ActionResult<Boquet> Create([FromBody] Boquet newBoquet)
        {
            try
            {
                return Ok(_service.Create(newBoquet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Boquet> Edit([FromBody] Boquet editBoquet, int id)
        {
            try
            {
                editBoquet.Id = id;
                return Ok(_service.Edit(editBoquet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Boquet> Delete(int id)
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