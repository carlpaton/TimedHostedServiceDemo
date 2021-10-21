using TimedHostedService.Worker.Domain.Models;

namespace TimedHostedService.Worker.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        /// <summary>
        /// Insert a new cart_item row
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        long Add(CartItem cartItem);

        /// <summary>
        /// Updates the existing cart_item row
        /// </summary>
        /// <param name="cartItem"></param>
        void Update(CartItem cartItem);

        /// <summary>
        /// Deletes the cart_item row
        /// </summary>
        /// <param name="cartItemId"></param>
        void Delete(int cartItemId);
    }
}
