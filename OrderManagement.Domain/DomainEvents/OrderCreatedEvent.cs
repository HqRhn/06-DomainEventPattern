using OrderManagement.Domain.Primitives;

namespace OrderManagement.Domain.DomainEvents
{
    public sealed record OrderCreatedEvent(string orderReference) : IDomainEvent
    {

    }

}
