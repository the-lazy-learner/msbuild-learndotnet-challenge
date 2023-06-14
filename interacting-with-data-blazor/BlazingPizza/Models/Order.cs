namespace BlazingPizza
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedTime { get; set; }

        public Address? DeliveryAddress { get; set; }

        public List<Pizza> Pizzas { get; set; } = new();

        public decimal GetTotalPrice() => Pizzas!.Sum(p => p.GetTotalPrice());

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}