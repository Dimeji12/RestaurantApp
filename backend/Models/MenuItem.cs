namespace ResturantApp.Models
{
public class MenuItem
{

        
       public int MenuItemId{get; set;}
        public string? Name { get; set; }
        public string ?Description { get; set; }
       
        public List<string>? Ingredients { get; set; }
        public List<string>? Allergens { get; set; }
        public bool Availability { get; set; }

 public int? OrderId { get; set;}

public List<Order>? Order { get; set;}

}
}