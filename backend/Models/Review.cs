namespace ResturantApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string? Comment { get; set; }
        public int ? Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
