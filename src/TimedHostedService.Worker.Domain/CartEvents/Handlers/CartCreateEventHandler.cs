using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimedHostedService.Worker.Domain.CartEvents.Events;
using TimedHostedService.Worker.Domain.CartEvents.Mappers;
using TimedHostedService.Worker.Domain.Interfaces;

namespace TimedHostedService.Worker.Domain.CartEvents.Handlers
{
    public class CartCreateEventHandler : IEventHandler
    {
        private readonly ILogger<CartCreateEventHandler> _logger;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartMapper _cartMapper;

        public CartCreateEventHandler(ILogger<CartCreateEventHandler> logger, ICartRepository cartRepository, 
            ICartItemRepository cartItemRepository, ICartMapper cartMapper)
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartMapper = cartMapper;
        }

        ///<inheritdoc/>
        public Task HandleAsync(CartEvent cartEvent)
        {
            var cart = _cartMapper.MapCart(cartEvent);
            var newCartDbId = _cartRepository.Add(cart);

            foreach (var cartItem in cart.CartItems)
            {
                cartItem.CartId = newCartDbId;
                _cartItemRepository.Add(cartItem);
            }

            _logger.LogInformation($"{cartEvent.EventType} OK");
            return Task.CompletedTask;
        }

        ///<inheritdoc/>
        public bool IsMatch(EventType eventType)
        {
            return eventType.Equals(EventType.CART_CREATE);
        }
    }
}
