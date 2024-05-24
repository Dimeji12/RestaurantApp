namespace ResturantApp.Models
{
   public class  Order
   {
        public int OrderId { get; set; } 
        public int CustomerId { get; set; }
        public int MenuItemId { get; set; }
        public Customer?  Customer { get; set; }
        public MenuItem? MenuItem { get; set; }
   }
}