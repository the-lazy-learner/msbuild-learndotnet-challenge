namespace BlazingPizza
{
    public class OrderWithStatus
    {
        public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
        public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);

        public Order? Order { get; set; }

        public string? StatusText { get; set; }

        public bool IsDelivered => StatusText == "Delivered";

        public static OrderWithStatus FromOrder(Order order)
        {
            // To simulate a real backend process, we fake status updates based on the amount
            // of time since the order was placed
            string statusText;
            var dispatchTime = order.CreatedTime.Add(PreparationDuration);

            if (DateTime.Now < dispatchTime)
            {
                statusText = "Preparing";
            }
            else if (DateTime.Now < dispatchTime + DeliveryDuration)
            {
                statusText = "Out for Delivery";
            }
            else
            {
                statusText = "Delivered";
            }

            return new OrderWithStatus
            {
                Order = order,
                StatusText = statusText
            };
        }
    }
}