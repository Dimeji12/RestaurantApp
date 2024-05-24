namespace ResturantApp.Models
{
    public class Customer
    {
public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int AddressId { get; set; }

        public Address? Address { get; set; }
        public List<Order>? Orders { get; set; }

        
    }
}