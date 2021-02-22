using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly RentalsService _service;

        public RentalsController(RentalsService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Rental>> GetAll()
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
        public ActionResult<Rental> GetById(int id)
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
        public ActionResult<Rental> Create([FromBody] Rental newRental)
        {
            try
            {
                return Ok(_service.Create(newRental));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Rental> Edit([FromBody] Rental editRental, int id)
        {
            try
            {
                editRental.Id = id;
                return Ok(_service.Edit(editRental));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Rental> Delete(int id)
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