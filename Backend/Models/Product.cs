namespace Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string MiniDescription { get; set; }
        public string imageUrl { get; set; }
        public bool IsDispo { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}