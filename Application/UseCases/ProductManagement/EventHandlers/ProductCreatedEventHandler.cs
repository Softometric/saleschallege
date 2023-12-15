using Confluent.Kafka;
using Domain.Events.ProductEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProductManagement.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedEventHandler> _logger;
        
        public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
        {
            _logger = logger;
          
        }
        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            //  _logger.LogInformation("Payment Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
