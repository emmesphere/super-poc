using SuperPoc.BuildingBlocks.Domain.Enums;
using SuperPoc.BuildingBlocks.Domain.Events.Payments;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public class Payment : AggregateRoot<Guid>
    {
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; private set; }

        private Payment() { }

        public Payment(Guid id, Guid orderId, decimal amount, PaymentMethod method) : base(id)
        {
            OrderId = orderId;
            Amount = amount;
            Method = method;
            Status = PaymentStatus.Pending;
        }

        public void MarkAsCompleted()
        {
            Status = PaymentStatus.Completed;
            AddDomainEvent(new PaymentProcessed(Id, OrderId, Amount, Method));
        }

        public void MarkAsFailed(string reason)
        {
            Status = PaymentStatus.Failed;
            AddDomainEvent(new PaymentFailed(Id, OrderId, reason));
        }
    }
}
