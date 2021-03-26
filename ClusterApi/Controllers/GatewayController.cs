using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClusterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : Controller
    {

        private readonly IConfiguration _config;

        public GatewayController(IConfiguration config)
        {
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("GetConfigDetails")]
        public async Task<object> GetConfigDetailsAsync()
        {
            Console.WriteLine("Inside the Gateway API for Config call");
            var configApiUri = _config.GetValue<string>("Config:ConfigService");
            object result = new object();
            Console.Write(configApiUri);
            try
            {
                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri("");
                client.BaseAddress = new Uri(configApiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("GetConfiguration");
                if (response.IsSuccessStatusCode)
                {

                    result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result.ToString());
                }

                else
                {
                    Console.WriteLine("Errro status code is : " + response.StatusCode.ToString());
                }
                return result;

            }

            catch (Exception ex)
            {
                throw ex;
            }
          
        }



        [HttpGet("GetEmployeeDetails")]
        public async Task<object> GetEmployeeDetails()
        {
            Console.WriteLine("Inside the Gateway API for Employee call");
            var configApiUri = _config.GetValue<string>("Config:EmployeeService");
            object result = new object();
            Console.Write(configApiUri);
            try
            {
                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri("");
                client.BaseAddress = new Uri(configApiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("GetEmployeeDetails");
                if (response.IsSuccessStatusCode)
                {

                    result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result.ToString());
                }

                else
                {
                    Console.WriteLine("Errro status code is : " + response.StatusCode.ToString());
                }
                return result;

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
