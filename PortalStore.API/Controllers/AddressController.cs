using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Entity;
using PortalStore.DTO;
using PortalStore.DTO.Address;
using PortalStore.DTO.Category;
using PortalStore.Service.IService;
using PortalStore.Service.Service;

namespace PortalStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }
        [HttpGet("{customerId}")]
        public IActionResult GetCustomerAddress(int customerId)
        {
            var response = _mapper.Map<List<AddressListDto>>(_addressService.GetCustomerAddress(customerId));
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<AddressListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<AddressListDto>>.Fail(500, "Kayıt Bulunamadı"));
        }
        [HttpGet("{id}")]
        public IActionResult GetAddress(int id)
        {
            var response = _mapper.Map<List<AddressListDto>>(_addressService.GetById(id));
            if (response.Count > 0)
            {
                return CreateActionResult(CustomResponseDto<List<AddressListDto>>.Success(200, response));
            }
            return CreateActionResult(CustomResponseDto<List<AddressListDto>>.Fail(500, "Kayıt Bulunamadı"));
        }
        [HttpPost]
        public IActionResult AddNewAddres(AddAddressDto addAddress)
        {
            var entity = _mapper.Map<Address>(addAddress);
            _addressService.Add(entity);
            if (entity.Id > 0)
            {
                return CreateActionResult(CustomResponseDto<AddAddressDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddAddressDto>.Fail(500, "Kayıt Sırasında Bir Hata Oluştu"));
        }
        [HttpPost]
        public IActionResult UpdateAddres(UpdateAddressDto updateAddress)
        {
            if (updateAddress.Id > 0)
            {
                _addressService.Update(_mapper.Map<Address>(updateAddress));
                return CreateActionResult(CustomResponseDto<UpdateAddressDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<UpdateAddressDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{id}")]
        public IActionResult GetByAddressId(int id)
        {
            if (id > 0)
            {
                var getById = _addressService.GetById(id);
                if (getById != null)
                {
                    var response = _mapper.Map<AddressListDto>(getById);
                    return CreateActionResult(CustomResponseDto<AddressListDto>.Success(200, response));
                }
                return CreateActionResult(CustomResponseDto<AddressListDto>.Fail(500, "Kayıt Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<AddressListDto>.Fail(500, "Id 0'dan büyük olmalıdır"));
        }
        [HttpGet("{id}")]
        public IActionResult ChangeAdressStatus(int id)
        {
            if (id > 0)
            {
                var entity = _addressService.GetById(id);
                entity.Status = entity.Status == true ? false : true;
                _addressService.Update(entity);
                return CreateActionResult(CustomResponseDto<AddAddressDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<AddAddressDto>.Fail(200,"Id 0'dan büyük olmalıdır"));
        }
    }
}
