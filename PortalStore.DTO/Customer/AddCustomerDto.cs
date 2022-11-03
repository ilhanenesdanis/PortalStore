namespace PortalStore.DTO.Customer
{
    public class AddCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long TCID { get; set; }
        public DateTime BirthDate { get; set; }
        public string GSM { get; set; }
    }
}
