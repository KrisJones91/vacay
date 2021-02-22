using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripsService _service;

        public TripsController(TripsService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Trip>> GetAll()
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
        public ActionResult<Trip> GetById(int id)
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
        public ActionResult<Trip> Create([FromBody] Trip newTrip)
        {
            try
            {
                return Ok(_service.Create(newTrip));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Trip> Edit([FromBody] Trip editTrip, int id)
        {
            try
            {
                editTrip.Id = id;
                return Ok(_service.Edit(editTrip));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")] // DELETE
        public ActionResult<Trip> Delete(int id)
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