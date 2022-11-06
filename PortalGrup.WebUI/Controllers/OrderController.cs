using Microsoft.AspNetCore.Mvc;
using PortalGrup.WebUI.APIHandler;
using PortalStore.DTO;
using PortalStore.DTO.Order;

namespace PortalStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IApiHandler _apiHandler;
        private readonly IConfiguration _configuration;

        public OrderController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllOrder;
            var get = _apiHandler.GetApi<CustomResponseDto<List<OrderListDto>>>(url);
            return View(get.Data);
        }
        public JsonResult CancelOrder(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.OrderCancel + "/" + id;
            var post = _apiHandler.GetApi<CustomResponseDto<AddOrderDto>>(url);
            return Json(new { success = true });
        }
    }
}
