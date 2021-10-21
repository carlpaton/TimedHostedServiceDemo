using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using Worker.Domain.Interfaces;
using Worker.Domain.Models;

namespace Worker.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository, IDisposable
    {
        private readonly MySqlConnection _context;

        public CartRepository(IOptions<ConnectionStringsOptions> options)
        {
            _context = new MySqlConnection(options.Value.FooDatabaseConnectionString);
        }

        ///<inheritdoc/>
        public long Add(Cart cart)
        {
            using (_context)
            {
                Open();

                return _context.Query<long>(
                        "sp_addcart",
                        new { cart.FeedId, cart.UserId, cart.DateUtc }, 
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
            }
        }

        ///<inheritdoc/>
        public void Delete(long cartId)
        {
            using (_context)
            {
                Open();

                _context.Execute(
                    "sp_deletecart", 
                    new { cartId }, 
                    commandType: CommandType.StoredProcedure);
            }
        }

        ///<inheritdoc/>
        public void Update(Cart cart)
        {
            using (_context)
            {
                Open();

                _context.Execute(
                    "sp_updatecart",
                    new { cart.DbId, cart.FeedId, cart.UserId, cart.DateUtc },
                    commandType: CommandType.StoredProcedure);
            }
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
