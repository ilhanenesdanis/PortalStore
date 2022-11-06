using Microsoft.AspNetCore.Mvc;
using PortalGrup.WebUI.APIHandler;
using PortalStore.DTO;
using PortalStore.DTO.Basket;
using PortalStore.DTO.Category;
using PortalStore.DTO.Customer;
using PortalStore.DTO.Product;
using PortalStore.WebUI.Models;

namespace PortalStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IApiHandler _apiHandler;
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllProduct;
            var categoryUrl = _configuration["BaseURL"] + UrlStrings.GetAllCategory;

            var getProduct = _apiHandler.GetApi<CustomResponseDto<List<ProductListDto>>>(url);
            var getCategory = _apiHandler.GetApi<CustomResponseDto<List<CategoryListDto>>>(categoryUrl);
            ProductVM product = new ProductVM()
            {
                Category = getCategory.Data,
                Product = getProduct.Data
            };
            return View(product);
        }
        public JsonResult AddNewProduct(AddProductDto addProductDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.AddNewProduct;
            var post = _apiHandler.PostApiString(addProductDto, url);
            return Json(new { success = true });
        }
        public IActionResult GetByProduct(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetByProductId + "/" + id;
            var categoryUrl = _configuration["BaseURL"] + UrlStrings.GetAllCategory;
            var get = _apiHandler.GetApi<CustomResponseDto<ProductListDto>>(url);
            var getCategory = _apiHandler.GetApi<CustomResponseDto<List<CategoryListDto>>>(categoryUrl);
            ProductVM product = new ProductVM()
            {
                Category = getCategory.Data,
                UpdateProduct = get.Data
            };
            return PartialView("_updateProduct", product);
        }
        public JsonResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.UpdateProduct;
            var post = _apiHandler.PostApiString(updateProductDto, url);
            return Json(new { success = true });
        }
        public JsonResult GetCustomerList()
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetAllCustomer;
            var get = _apiHandler.GetApi<CustomResponseDto<List<CustomerListDto>>>(url);
            return Json(get.Data);
        }
        public JsonResult AddBasket(AddBasketDto addBasketDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.AddToBasket;
            var post = _apiHandler.PostApiString(addBasketDto, url);
            return Json(new { success = true });
        }
        public JsonResult ChangeStatus(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.ChangeProductStatus + "/" + id;
            var post = _apiHandler.GetApi<CustomResponseDto<AddProductDto>>(url);
            return Json(new { success = true });
        }
        
    }
}
