using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetEmployeeDetails")]
        public object GetEmployeeDetails()
        {
            Console.WriteLine("Inside the Employee API");
            return "Response from Employee API";


        }
    }
}
