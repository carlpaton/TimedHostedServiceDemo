using Worker.Domain.Models;

namespace Worker.Domain.Interfaces
{
    public interface ICartRepository
    {
        /// <summary>
        /// Insert a new cart row
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>Returns the new database id from `foo.cart.db_id`</returns>
        long Add(Cart cart);

        /// <summary>
        /// Updates the existing cart row
        /// </summary>
        /// <param name="cart"></param>
        void Update(Cart cart);

        /// <summary>
        /// Deletes the cart row
        /// </summary>
        /// <param name="cartId"></param>
        void Delete(long cartId);
    }
}
