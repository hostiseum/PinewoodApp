using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Mime;
using System.Text.Json;
using System.Text;
using PinewoodApp.CustomerDMS.Helpers;
using PinewoodApp.CustomerDMS.Areas.Customer.Models;

namespace PinewoodApp.CustomerDMS.Areas.Customer.Controllers
{
    [Area("Customer")]
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

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var httpClient = _httpHelper.GetHttpClient();
            var customer = await httpClient.GetFromJsonAsync<CustomerModel>($"/api/customer/{id}");
            return View(customer);
            
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer.Models.CustomerModel customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(customer);
                    
                }

                var httpClient = _httpHelper.GetHttpClient();
                using StringContent json = new(
                                               JsonSerializer.Serialize(customer, new JsonSerializerOptions(JsonSerializerDefaults.Web)),
                                               Encoding.UTF8,
                                               MediaTypeNames.Application.Json);


                using HttpResponseMessage httpResponse =
                    await httpClient.PostAsync("/api/customer", json);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = _httpHelper.GetHttpClient();
            var customer = await httpClient.GetFromJsonAsync<CustomerModel>($"/api/customer/{id}");
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomerModel customer)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    return View(customer);

                }

                var httpClient = _httpHelper.GetHttpClient();
                using StringContent json = new(
                                               JsonSerializer.Serialize(customer, new JsonSerializerOptions(JsonSerializerDefaults.Web)),
                                               Encoding.UTF8,
                                               MediaTypeNames.Application.Json);


                using HttpResponseMessage httpResponse =
                    await httpClient.PutAsync("/api/customer", json);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
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
    }
}
