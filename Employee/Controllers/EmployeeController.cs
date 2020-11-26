using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Application.APP.Interface;
using DDD.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeApplication _employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_employeeApplication.Get());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar a lista de funcionários. " + ex.ToString());
            }
        }       

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeCreateViewModel employee)
        {
            try
            {
                _employeeApplication.Post(employee);
                return Created("api/Employee", "Criado com sucesso!");
            }
            catch(Exception ex)
            {
                return BadRequest("Erro ao inserir os dados. " + ex.ToString());
            }
        }
    }
}