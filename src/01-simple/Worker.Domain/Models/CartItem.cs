namespace Worker.Domain.Models
{
    public class CartItem
    {
        public long DbId { get; set; }
        public string FeedId { get; set; }
        public long CartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}
