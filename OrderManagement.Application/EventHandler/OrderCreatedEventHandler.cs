using MediatR;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.DomainEvents;

namespace OrderManagement.Application.EventHandler
{
    internal sealed class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
       private readonly IEmailService _emailService;

       public OrderCreatedEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendOrderAcceptedConfirmationEmailAsync();
        }
    }
}
