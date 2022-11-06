using PortalStore.DTO.Base;

namespace PortalStore.DTO.Address
{
    public class UpdateAddressDto:BaseDto
    {
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ZipCode { get; set; }
        public int CustomerId { get; set; }
    }
}
