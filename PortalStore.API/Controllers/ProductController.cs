using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Entity;
using PortalStore.DTO;
using PortalStore.DTO.Product;
using PortalStore.Service.IService;

namespace PortalStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var response = _mapper.Map<List<ProductListDto>>(_productService.GetAllProduct());
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<ProductListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<ProductListDto>>.Fail(500, "Kayıt Bulunamadı"));
        }
        [HttpGet("{id}")]
        public IActionResult GetByProductId(int id)
        {
            if (id > 0)
            {
                var response = _mapper.Map<ProductListDto>(_productService.GetById(id));
                if (response != null)
                {
                    return CreateActionResult(CustomResponseDto<ProductListDto>.Success(200, response));
                }
                return CreateActionResult(CustomResponseDto<ProductListDto>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<ProductListDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpPost]
        public IActionResult AddNewProduct(AddProductDto addProductDto)
        {
            var entity = _mapper.Map<Product>(addProductDto);
            _productService.Add(entity);
            if (entity.Id > 0)
            {
                return CreateActionResult(CustomResponseDto<List<AddProductDto>>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<List<AddProductDto>>.Fail(500, "Kayıt Sırasında Hata Gerçekleşti"));
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductDto updateProduct)
        {
            if (updateProduct.Id > 0)
            {
                var get = _productService.GetById(updateProduct.Id);
                if (get != null)
                {
                    get.OldPrice = get.Price == updateProduct.Price ? 0 : get.Price;
                    get.Price = updateProduct.Price;
                    get.CategoryId = updateProduct.CategoryId;
                    get.Description = updateProduct.Description;
                    get.Name = updateProduct.Name;
                    _productService.Update(get);
                    return CreateActionResult(CustomResponseDto<UpdateProductDto>.Success(200));
                }
                return CreateActionResult(CustomResponseDto<UpdateProductDto>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<UpdateProductDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{id}")]
        public IActionResult ChangeProductStatus(int id)
        {
            if (id > 0)
            {
                var entity = _productService.GetById(id);
                entity.Status = entity.Status == true ? false : true;
                _productService.Update(entity);
                return CreateActionResult(CustomResponseDto<AddProductDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddProductDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }

    }
}
