using SuperPoc.BuildingBlocks.Domain.Enums;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public class Shipment : AggregateRoot<Guid>
    {
        public Guid OrderId { get; private set; }
        public ShipmentStatus Status { get; private set; }
        public string TrackingCode { get; private set; }

        private Shipment() { }

        public Shipment(Guid id, Guid orderId, string trackingCode) : base(id)
        {
            OrderId = orderId;
            TrackingCode = trackingCode;
            Status = ShipmentStatus.Pending;
        }

        public void Start()
        {
            Status = ShipmentStatus.InTransit;
        }

        public void Deliver()
        {
            Status = ShipmentStatus.Delivered;
        }
    }
}
