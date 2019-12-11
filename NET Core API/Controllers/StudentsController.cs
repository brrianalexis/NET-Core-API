using ContosoAPI.Models;
using ContosoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly StudentsService _studentsService;

        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        //  C
        //  POST api/<controller>
        [HttpPost]
        public ActionResult<Students> Create(Students student)
        {
            _studentsService.Create(student);
            return Ok();
        }

        //  R
        //  GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Students>> Get() =>
            _studentsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Students> Get(string id)
        {
            var student = _studentsService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        //  U
        //  PUT api/<controller>
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Students studentIn)
        {
            var student = _studentsService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentsService.Update(id, studentIn);
            return NoContent();
        }

        //  D
        //  DELETE api/<controller>
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var student = _studentsService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentsService.Remove(student.Id);
            return NoContent();
        }
    }
}