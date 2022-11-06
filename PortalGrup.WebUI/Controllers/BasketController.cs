using Microsoft.AspNetCore.Mvc;
using PortalGrup.WebUI.APIHandler;
using PortalStore.DTO;
using PortalStore.DTO.Address;
using PortalStore.DTO.Basket;
using PortalStore.DTO.Order;

namespace PortalStore.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IApiHandler _apiHandler;
        private readonly IConfiguration _configuration;

        public BasketController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index(int customerId)
        {
            if (customerId > 0)
            {
                ViewBag.customerId = customerId;
                var url = _configuration["BaseURL"] + UrlStrings.GetBasketByCustomerId + "/" + customerId;
                var get = _apiHandler.GetApi<CustomResponseDto<List<BasketListDto>>>(url);
                return View(get.Data);
            }
            else
            {
                var url = _configuration["BaseURL"] + UrlStrings.GetAllBasket;
                var get = _apiHandler.GetApi<CustomResponseDto<List<BasketListDto>>>(url);
                return View(get.Data);

            }
        }
        public JsonResult UpdateBasket(int quantity,int id)
        {
            UpdateBasketDto updateBasket = new UpdateBasketDto()
            {
                Id = id,
                Quantity = quantity
            };
            var url = _configuration["BaseURL"] + UrlStrings.UpdateBasket;
            var post = _apiHandler.PostApiString(updateBasket, url);
            return Json(new {success=true});
        }
        public JsonResult GetBasket(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetBasket + "/" + id;
            var get = _apiHandler.GetApi<CustomResponseDto<BasketListDto>>(url);
            return Json(get.Data);
        }
        public JsonResult RemoveBasket(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.RemoveBasket + "/" + id;
            var post = _apiHandler.GetApi<CustomResponseDto<UpdateBasketDto>>(url);
            return Json(new { success = true });
        }
        public JsonResult GetCustomerAddress(int customerId)
        {
            var url = _configuration["BaseURL"] + UrlStrings.CustomerAddress + "/" + customerId;
            var getList = _apiHandler.GetApi<CustomResponseDto<List<AddressListDto>>>(url);
            return Json(getList.Data);
        }
        public JsonResult CreateOrder(AddOrderDto addOrderDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.CreateOrder;
            var post = _apiHandler.PostApiString(addOrderDto, url);
            return Json(new { success = true });
        }
    }
}
