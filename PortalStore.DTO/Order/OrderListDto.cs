using PortalStore.DTO.Address;
using PortalStore.DTO.Base;
using PortalStore.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.DTO.Order
{
    public class OrderListDto : BaseDto
    {
        public int CustomerId { get; set; }
        public CustomerListDto Customer { get; set; }
        public int AddressId { get; set; }
        public AddressListDto Address { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
