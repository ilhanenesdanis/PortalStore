using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Entity;
using PortalStore.DTO;
using PortalStore.DTO.Order;
using PortalStore.Service.IService;

namespace PortalStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderItemService _orderItem;
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public OrderController(IOrderItemService orderItem, IOrderService orderService, IMapper mapper, IBasketService basketService)
        {
            _orderItem = orderItem;
            _orderService = orderService;
            _mapper = mapper;
            _basketService = basketService;
        }
        [HttpPost]
        public IActionResult CreateOrder(AddOrderDto addOrder)
        {
            var entity = _mapper.Map<Order>(addOrder);
            _orderService.Add(entity);
            if (entity.Id > 0)
            {
                var getBasket = _basketService.GetBasketByCustomerId(addOrder.CustomerId).ToList();
                foreach (var item in getBasket)
                {
                    OrderItem orderItem = new()
                    {
                        OrderId = entity.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Product.Price
                    };
                    _orderItem.Add(orderItem);
                }
                _basketService.DeleteRange(getBasket);
                return CreateActionResult(CustomResponseDto<AddOrderDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddOrderDto>.Fail(500, "İşlem Sırasında Hata"));
        }
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var response = _mapper.Map<List<OrderListDto>>(_orderService.GetAllOrder());
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<OrderListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<OrderListDto>>.Fail(500, "Kayıt Bulunamadı"));
        }
        [HttpGet("{id}")]
        public IActionResult OrderCancel(int id)
        {
            if (id > 0)
            {
                var get = _orderService.GetById(id);
                var getOrderItem = _orderItem.GetBy(x => x.OrderId == id).ToList();
                _orderItem.DeleteRange(getOrderItem);
                _orderService.Delete(get);
                return CreateActionResult(CustomResponseDto<AddOrderDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddOrderDto>.Fail(500,"Id 0'dan büyük olmalıdır"));
        }
    }
}
