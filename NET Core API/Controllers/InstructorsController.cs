using ContosoAPI.Models;
using ContosoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : Controller
    {
        private readonly InstructorsService _instructorsService;

        public InstructorsController(InstructorsService instructorsService)
        {
            _instructorsService = instructorsService;
        }

        //  C
        //  POST api/<controller>
        [HttpPost]
        public ActionResult<Instructors> Create(Instructors instructor)
        {
            _instructorsService.Create(instructor);
            return Ok();
        }

        //  R
        //  GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Instructors>> Get() =>
            _instructorsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetInstructor")]
        public ActionResult<Instructors> Get(string id)
        {
            var instructor = _instructorsService.Get(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }

        //  U
        //  PUT api/<controller>/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Instructors instructorIn)
        {
            var instructor = _instructorsService.Get(id);

            if (instructor == null)
            {
                return NotFound();
            }

            _instructorsService.Update(id, instructorIn);
            return NoContent();
        }

        //  D
        //  DELETE api/<controller>/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var instructor = _instructorsService.Get(id);

            if (instructor == null)
            {
                return NotFound();
            }

            _instructorsService.Remove(instructor.Id);
            return NoContent();
        }
    }
}