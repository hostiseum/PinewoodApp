using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PinewoodApp.CustomerDMS.Areas.Customer.Models;
using PinewoodApp.CustomerDMS.Helpers;
using PinewoodApp.CustomerDMS.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace PinewoodApp.CustomerDMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpHelper _httpHelper;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpHelper httpHelper)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration; 
            _httpHelper = httpHelper;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCustomers()
        {
            try
            {
                using var httpClient = _httpHelper.GetHttpClient();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("api/customer");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var customers = await responseMessage.Content.ReadFromJsonAsync<CustomerModel[]>();
                    if (customers != null)
                    {
                        return new JsonResult(Ok(customers));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new JsonResult(StatusCode(500));
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCustomer(int id)
        {
            using var httpClient = _httpHelper.GetHttpClient();
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync($"api/customer/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return new JsonResult(Ok("Customer deleted successfully."));
            }

            return new JsonResult(BadRequest());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
