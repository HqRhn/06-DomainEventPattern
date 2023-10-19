using OrderManagement.Domain.DomainEvents;
using OrderManagement.Domain.Primitives;

namespace OrderManagement.Domain.Entities
{
    public sealed class Order : AggregateRoot
    {
        public Order(string name, DateTime scheduledOn)
        {
            OrderReference = name;
            CreatedOn = scheduledOn;
        }
        public Order()
        {
        }

        public Order CreateNewOrder(string orderReference, DateTime createdOn)
        {
            return  new Order { OrderReference = orderReference, CreatedOn = createdOn };
        }

        public void OrderCreated(string orderReference)
        {
            RaiseDomainEvent(new OrderCreatedEvent(orderReference));
        }
        public string OrderReference { get;  set; }
        public DateTime CreatedOn { get;  set; }
    }
}
