using Microsoft.AspNetCore.Mvc;
using PortalGrup.WebUI.APIHandler;
using PortalStore.DTO;
using PortalStore.DTO.Category;

namespace PortalGrup.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IApiHandler _apiHandler;
        private readonly IConfiguration _configuration;
        public CategoryController(IApiHandler apiHandler, IConfiguration configuration)
        {
            _apiHandler = apiHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var apiUrl = _configuration["BaseURL"] + UrlStrings.GetAllCategory;
            var result = _apiHandler.GetApi<CustomResponseDto<List<CategoryListDto>>>(apiUrl);
            return View(result);
        }
        [HttpPost]
        public JsonResult AddNewCategory(AddCategoryDto addCategoryDto)
        {
            var url = _configuration["BaseURL"] + UrlStrings.AddCategory;
            var post = _apiHandler.PostApiString(addCategoryDto, url);
            return Json(new { success = true });
        }
        public JsonResult GetByCategoryId(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.GetByCategoryId + "/" + id;
            var get = _apiHandler.GetApi<CustomResponseDto<CategoryListDto>>(url);
            return Json(get.Data);
        }
        [HttpPost]
        public JsonResult UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var url = _configuration["BaseURL"] + UrlStrings.UpdateCategory;
            var post = _apiHandler.PostApiString(updateCategory, url);
            return Json(new { success = true });
        }
        public JsonResult ChangeStatus(int id)
        {
            var url = _configuration["BaseURL"] + UrlStrings.ChangeStatus + "/" + id;
            var change = _apiHandler.GetApi<CustomResponseDto<CategoryListDto>>(url);
            return Json(new { success = true });
        }
    }
}
