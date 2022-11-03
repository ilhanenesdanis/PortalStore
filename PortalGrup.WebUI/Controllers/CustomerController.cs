using Microsoft.AspNetCore.Mvc;
using PortalGrup.WebUI.APIHandler;
using PortalStore.DTO;
using PortalStore.DTO.Customer;
using System.Xml.Linq;

namespace PortalStore.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IApiHandler _apiHandler;
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllCustomer;
            var getList = _apiHandler.GetApi<CustomResponseDto<List<CustomerListDto>>>(url);
            return View(getList);
        }
        public async Task<JsonResult> CheckTc(long tc, string name, string surname, DateTime BirthDate)
        {
            var client = new TcDogrulama.KPSPublicSoapClient(TcDogrulama.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(tc), name, surname, BirthDate.Year);
            var results = response.Body.TCKimlikNoDogrulaResult;
            return Json(results);
        }
        [HttpPost]
        public JsonResult AddCustomer(AddCustomerDto addCustomerDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.AddNewCustomer;
            var post = _apiHandler.PostApiString(addCustomerDto, url);
            return Json(new { success = true });
        }

        public IActionResult GetByCustomer(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetByCustomerId + "/" + id;
            var get = _apiHandler.GetApi<CustomResponseDto<CustomerListDto>>(url);
            return PartialView("_updateCustomer",get.Data);
        }
        public JsonResult UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.UpdateCustomer;
            var post=_apiHandler.PostApiString(updateCustomerDto, url);
            return Json(new { success = true });
        }

    }
}
