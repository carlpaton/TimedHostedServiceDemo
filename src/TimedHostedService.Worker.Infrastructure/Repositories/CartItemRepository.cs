using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using TimedHostedService.Worker.Domain.Interfaces;
using TimedHostedService.Worker.Domain.Models;

namespace TimedHostedService.Worker.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository, IDisposable
    {
        private readonly MySqlConnection _context;

        public CartItemRepository(IOptions<ConnectionStringsOptions> options)
        {
            _context = new MySqlConnection(options.Value.FooDatabaseConnectionString);
        }

        public long Add(CartItem cartItem)
        {
            using (_context)
            {
                Open();

                return _context.Query<long>(
                        "sp_addcartitem",
                        new { cartItem.FeedId, cartItem.CartId, cartItem.Quantity, cartItem.UnitCost },
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
        }

        public void Delete(int cartItemId)
        {
            // TODO - CartItemRepository Delete
            throw new System.NotImplementedException();
        }

        public void Update(CartItem cartItem)
        {
            // TODO - CartItemRepository Update
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _context.Close();
            _context.Dispose();
        }

        private void Open()
        {
            if (_context.State == ConnectionState.Closed)
                _context.Open();
        }
    }
}
