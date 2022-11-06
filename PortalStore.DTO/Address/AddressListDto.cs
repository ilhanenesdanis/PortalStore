﻿using PortalStore.DTO.Base;
using PortalStore.DTO.Customer;

namespace PortalStore.DTO.Address
{
    public class AddressListDto : BaseDto
    {
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ZipCode { get; set; }
        public int CustomerId { get; set; }
        public CustomerListDto Customer { get; set; }
    }
}
