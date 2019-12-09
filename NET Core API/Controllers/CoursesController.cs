using ContosoAPI.Models;
using ContosoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly CoursesService _coursesService;

        public CoursesController(CoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        //  C
        //  POST api/<controller>
        [HttpPost]
        public ActionResult<Courses> Create(Courses course)
        {
            _coursesService.Create(course);
            return CreatedAtRoute("PostCourse", course);
        }

        //  R
        //  GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Courses>> Get() =>
            _coursesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCourse")]
        public ActionResult<Courses> Get(string id)
        {
            var course = _coursesService.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        //  U
        //  PUT api/<controller>/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Courses courseIn)
        {
            var course = _coursesService.Get(id);

            if (course == null)
            {
                return NotFound();
            }
            _coursesService.Update(id, courseIn);
            return NoContent();
        }

        //  D
        //  DELETE api/<controller>/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var course = _coursesService.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            _coursesService.Remove(course.Id);
            return NoContent();
        }
    }
}