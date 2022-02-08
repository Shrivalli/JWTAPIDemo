using Employee_Handson.Filters;
using Employee_Handson.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Handson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [CustomAuthFilter]  //uncomment this to test custom auth and exception filter
    //[CustomExceptionFilter]
    [Authorize(Roles = "admin,POC")]
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllEmployess")]
        public ActionResult<Employee> GetStandrad()
        {
            List<Employee> list = Employee.GetStandardEmployeesList();
            return Ok(list);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id,Employee emp)
        {
            var res = Employee.UpdateEmp(id, emp);
            return Ok(res);

        }




    }
}
