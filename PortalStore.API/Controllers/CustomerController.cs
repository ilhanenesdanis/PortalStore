using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Entity;
using PortalStore.DTO;
using PortalStore.DTO.Customer;
using PortalStore.Service.IService;

namespace PortalStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var response = _mapper.Map<List<CustomerListDto>>(_customerService.GetAll());
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<CustomerListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<CustomerListDto>>.Success(200));
        }
        [HttpPost]
        public IActionResult AddNewCustomer(AddCustomerDto addCustomerDto)
        {
            var entity = _mapper.Map<Customer>(addCustomerDto);
            _customerService.Add(entity);
            if (entity.Id > 0)
            {
                return CreateActionResult(CustomResponseDto<AddCustomerDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddCustomerDto>.Fail(500, "Kayıt Eklerken bir hata oluştu"));
        }
        [HttpGet("{id}")]
        public IActionResult GetByCustomerId(int id)
        {
            var response = _mapper.Map<CustomerListDto>(_customerService.GetBy(x => x.Id == id).FirstOrDefault());
            if (response != null)
            {
                return CreateActionResult(CustomResponseDto<CustomerListDto>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<CustomerListDto>.Fail(500, "Kayıt Bulunamadı"));
        }
        [HttpPost]
        public IActionResult UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            if (updateCustomer.Id > 0)
            {
                _customerService.Update(_mapper.Map<Customer>(updateCustomer));
                return CreateActionResult(CustomResponseDto<UpdateCustomerDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<UpdateCustomerDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{id}")]
        public IActionResult ChangeCustomerStatus(int id)
        {
            if (id > 0)
            {
                var getByCustomer = _customerService.GetBy(x => x.Id == id).FirstOrDefault();
                if (getByCustomer != null)
                {
                    getByCustomer.Status = getByCustomer.Status == true ? false : true;
                    _customerService.Update(getByCustomer);
                    return CreateActionResult(CustomResponseDto<UpdateCustomerDto>.Success(200));
                }
                return CreateActionResult(CustomResponseDto<UpdateCustomerDto>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<UpdateCustomerDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
    }
}
