﻿using dental_clinic.entities;
using Microsoft.AspNetCore.Mvc;
using dental_clinic.Core.services;
using dental_clinic.Serivce;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly ITurnServices _turnService;
        public TurnsController(ITurnServices turnService)
        {
            _turnService = turnService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_turnService.GetList());
        }

        // GET api/<turns>/5
        [HttpGet("{id}")]
        public ActionResult Getid(int id)
        {
            var den = _turnService.GetById(id);
            if (den != null)
            {
                return Ok(den);
            }
            return NotFound();
        }

        // POST api/<turns>
        [HttpPost]
        public ActionResult Post([FromBody] turn d)
        {
            var den = _turnService.GetById(d.Id);
            if (den != null)
            {
                return Conflict();
            }
            _turnService.Add(d);
            return Ok();

        }

        // DELETE api/<turns>/5
        [HttpDelete("{id}")]
        public ActionResult Put(int id, [FromBody] turn value)
        {
            var existingTurn = _turnService.GetById(id);

            if (existingTurn == null)
            {
                return NotFound(); // אם הרופא לא נמצא, נחזיר שגיאה 404
            }

            try
            {
                // עדכון כל השדות של האובייקט הקיים לפי הערכים החדשים
                existingTurn.TurnNum = value.TurnNum;
                existingTurn.Date = value.Date;
                existingTurn.Time = value.Time;
                existingTurn.Type = value.Type;
                existingTurn.DurantionOfTreatment = value.DurantionOfTreatment;
                existingTurn.DoctorName = value.DoctorName;
                existingTurn.Id = value.Id;

                // קריאה לשירות לעדכון הרופא
                _turnService.Put(existingTurn);

                return NoContent(); // החזרה של 204 במידה והעדכון עבר בהצלחה
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
