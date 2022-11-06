using Microsoft.AspNetCore.Mvc;
using PortalGrup.WebUI.APIHandler;
using PortalStore.DTO;
using PortalStore.DTO.Address;

namespace PortalStore.WebUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IApiHandler _apiHandler;
        private readonly IConfiguration _configuration;

        public AddressController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index(int customerId)
        {
            var url = _configuration["BaseURL"] + UrlStrings.CustomerAddress + "/" + customerId;
            var getList = _apiHandler.GetApi<CustomResponseDto<List<AddressListDto>>>(url);
            if (getList.Data.Count == 0)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View(getList.Data);
        }
        public JsonResult AddNewCustomerAddress(AddAddressDto addAddress)
        {
            var url = _configuration["BaseURL"] + UrlStrings.AddNewAddres;
            var post = _apiHandler.PostApiString(addAddress, url);
            return Json(new { success = true });
        }
        public JsonResult UpdateAddress(UpdateAddressDto updateAddress)
        {
            var url = _configuration["BaseURL"] + UrlStrings.UpdateAddres;
            var post = _apiHandler.PostApiString(updateAddress, url);
            return Json(new { success = true });
        }
        public IActionResult GetAddress(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetByAddressId + "/" + id;
            var get = _apiHandler.GetApi<CustomResponseDto<AddressListDto>>(url);
            return PartialView("_updateAddress", get.Data);
        }
        public JsonResult ChangeStatus(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.ChangeAdressStatus + "/" + id;
            var post = _apiHandler.GetApi<CustomResponseDto<AddAddressDto>>(url);
            return Json(new { success = true });
        }
    }
}
