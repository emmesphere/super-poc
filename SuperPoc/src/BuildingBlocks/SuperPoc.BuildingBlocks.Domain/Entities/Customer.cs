using SuperPoc.BuildingBlocks.Domain.Events.Customers;
using SuperPoc.BuildingBlocks.Domain.ValueObjects;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public class Customer : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }

        private Customer() { } 

        public Customer(Guid id, string name, Email email) : base(id)
        {
            Name = name;
            Email = email;
        }

        public void UpdateEmail(Email newEmail)
        {
            string oldEmail = Email.Value!;
            Email = newEmail;
            AddDomainEvent(new CustomerEmailUpdated(Id, oldEmail!, newEmail.Value!));
        }
    }
}
