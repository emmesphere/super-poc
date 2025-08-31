namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total => Quantity * UnitPrice;

        public OrderItem() { }

        public OrderItem(Guid orderId, Guid productId, string productName, int quantity, decimal unitPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }


    }

}
