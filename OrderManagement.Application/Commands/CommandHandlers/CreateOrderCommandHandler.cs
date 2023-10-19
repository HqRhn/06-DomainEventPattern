using MediatR;
using OrderManagement.Domain.Entities;
using OrderManagement.Repository.Persistence.Repositories;

namespace OrderManagement.Application.Commands.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order();

            var newOrder = order.CreateNewOrder(request.OrderReference,request.CreatedOn);
            _orderRepository.AddOrder(newOrder);

            order.OrderCreated(newOrder.OrderReference);
            return newOrder;
        }
    }
}
