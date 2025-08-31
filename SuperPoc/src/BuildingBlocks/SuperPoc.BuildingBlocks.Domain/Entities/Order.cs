using SuperPoc.BuildingBlocks.Domain.Enums;
using SuperPoc.BuildingBlocks.Domain.Events.Orders;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public class Order : AggregateRoot<Guid> 
    { 
        private readonly List<OrderItem> _items = new();

        public Guid CustomerId { get; private set; }
        public decimal TotalAmount => _items.Sum(i => i.Total);
        public OrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        protected Order() { }

        public Order(Guid id, Guid customerId) : base(id)
        {
            CustomerId = customerId;
            Status = OrderStatus.Pending;
        }

        public void AddItem(Guid productId, string name, int quantity, decimal price)
        {
            var item = new OrderItem( Id, productId, name, quantity, price);
            _items.Add(item);
        }

        public void Confirm()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Apenas pedidos pendentes podem ser confirmados.");

            Status = OrderStatus.Confirmed;
            AddDomainEvent(new OrderConfirmed(Id, CustomerId, TotalAmount));
        }

        public void Cancel(string reason)
        {
            Status = OrderStatus.Canceled;
            AddDomainEvent(new OrderCancelled(Id, CustomerId, reason));
        }

    }
}
