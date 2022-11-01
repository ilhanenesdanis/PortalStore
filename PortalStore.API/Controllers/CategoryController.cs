using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Entity;
using PortalStore.DTO;
using PortalStore.DTO.Category;
using PortalStore.Service.IService;

namespace PortalStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var response = _mapper.Map<List<CategoryListDto>>(_categoryService.GetBy(x => x.Status == true).ToList());
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<CategoryListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<CategoryListDto>>.Fail(500, "Kayıt Bulunamadı"));
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            var entity = _mapper.Map<Category>(addCategoryDto);
            _categoryService.Add(entity);
            if (entity.Id > 0)
            {
                return CreateActionResult(CustomResponseDto<AddCategoryDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddCategoryDto>.Fail(500, "Kayıt Sırasında Hata Meydana Geldi"));
        }
        [HttpGet("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            if (id > 0)
            {
                var removeEntity = _categoryService.GetById(id);
                _categoryService.Delete(removeEntity);
                return CreateActionResult(CustomResponseDto<AddCategoryDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddCategoryDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto.Id > 0)
            {
                _categoryService.Update(_mapper.Map<Category>(updateCategoryDto));
                return CreateActionResult(CustomResponseDto<UpdateCategoryDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<UpdateCategoryDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{id}")]
        public IActionResult GetByCategoryId(int id)
        {
            if (id > 0)
            {
                var getByCategory = _mapper.Map<CategoryListDto>(_categoryService.GetBy(x => x.Id == id).FirstOrDefault());
                if (getByCategory != null)
                {
                    return CreateActionResult(CustomResponseDto<CategoryListDto>.Success(200, getByCategory));
                }
                return CreateActionResult(CustomResponseDto<CategoryListDto>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<UpdateCategoryDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
    }
}
