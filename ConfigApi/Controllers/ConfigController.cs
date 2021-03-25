using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : Controller
    {

        private readonly IConfiguration _config;

        public ConfigController(IConfiguration config)
        {
            _config = config;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet("GetConfiguration")]
        public string GetConfiguration()
        {
            
            return "Response from Config API" ;

        }
    }
}
