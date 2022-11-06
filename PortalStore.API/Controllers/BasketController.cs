using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Entity;
using PortalStore.DTO;
using PortalStore.DTO.Basket;
using PortalStore.Service.IService;

namespace PortalStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IMapper mapper, IBasketService basketService)
        {
            _mapper = mapper;
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetAllBasket()
        {
            var response = _mapper.Map<List<BasketListDto>>(_basketService.GetAllBasket().ToList());
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Fail(200, "Kayıt Bulunamadı"));
        }
        [HttpGet("{id}")]
        public IActionResult GetBasket(int id)
        {
            if (id > 0)
            {
                var response = _mapper.Map<BasketListDto>(_basketService.GetById(id));
                if (response!=null)
                {
                    return CreateActionResult(CustomResponseDto<BasketListDto>.Success(200, response));
                }
                return CreateActionResult(CustomResponseDto<BasketListDto>.Fail(200, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<BasketListDto>.Fail(200, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{customerId}")]
        public IActionResult GetBasketByCustomerId(int customerId)
        {
            if (customerId > 0)
            {
                var response = _mapper.Map<List<BasketListDto>>(_basketService.GetBasketByCustomerId(customerId).ToList());
                if (response.Count > 0)
                {
                    return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Success(200, response));
                }
                return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Fail(200, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Fail(200, "Id 0'dan büyük olmalıdır"));
        }
        [HttpPost]
        public IActionResult AddToBasket(AddBasketDto addBasketDto)
        {
            var entity = _mapper.Map<Basket>(addBasketDto);
            _basketService.Add(entity);
            if (entity.Id > 0)
            {
                return CreateActionResult(CustomResponseDto<AddBasketDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddBasketDto>.Fail(500, "Kayıt Sırasında Hata Gerçekleşti"));
        }
        [HttpPost]
        public IActionResult UpdateBasket(UpdateBasketDto updateBasketDto)
        {
            if (updateBasketDto.Id > 0)
            {
                var get = _basketService.GetById(updateBasketDto.Id);
                get.Quantity = updateBasketDto.Quantity;
                
                _basketService.Update(get);
                return CreateActionResult(CustomResponseDto<UpdateBasketDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<UpdateBasketDto>.Fail(200, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{customerId}")]
        public IActionResult BasketClear(int customerId)
        {
            if (customerId > 0)
            {
                var basketList = _basketService.GetBy(x => x.CustomerId == customerId).ToList();
                if (basketList.Count > 0)
                {
                    _basketService.DeleteRange(basketList);
                    return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Success(200));
                }
                return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<UpdateBasketDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{id}")]
        public IActionResult RemoveBasket(int id)
        {
            if (id > 0)
            {
                var basket = _basketService.GetById(id);
                if (basket != null)
                {
                    _basketService.Delete(basket);
                    return CreateActionResult(CustomResponseDto<UpdateBasketDto>.Success(200));
                }
                return CreateActionResult(CustomResponseDto<List<BasketListDto>>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<UpdateBasketDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
    }
}
