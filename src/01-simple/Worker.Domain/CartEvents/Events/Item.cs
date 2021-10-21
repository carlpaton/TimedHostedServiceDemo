namespace Worker.Domain.CartEvents.Events
{
    public class Item
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal UnitCost { get; set; }
    }
}
