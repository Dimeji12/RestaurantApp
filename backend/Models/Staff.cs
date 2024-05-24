namespace ResturantApp.Models
{
    public class Staff
    {

        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public string? StaffEmail { get; set; }
        public int AddressId { get; set; }

        public Address? Address { get; set; }
      
    }
}



