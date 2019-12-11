using ContosoAPI.Models;
using ContosoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        private readonly DepartmentsService _departmentsService;

        public DepartmentsController(DepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        //  C
        //  POST api/<controller>
        [HttpPost]
        public ActionResult<Departments> Create(Departments department)
        {
            _departmentsService.Create(department);
            return Ok();
        }

        //  R
        //  GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Departments>> Get() =>
            _departmentsService.Get();

        //  GET api/<controller>/5
        [HttpGet("{id:length(24)}", Name = "GetDepartment")]
        public ActionResult<Departments> Get(string id)
        {
            var department = _departmentsService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        //  U
        //  PUT api/<controller>/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Departments departmentIn)
        {
            var department = _departmentsService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            _departmentsService.Update(id, departmentIn);
            return NoContent();
        }

        //  D
        //  DELETE api/<controller>/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var department = _departmentsService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            _departmentsService.Remove(department.Id);
            return NoContent();
        }
    }
}