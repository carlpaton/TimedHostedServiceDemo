using System;
using System.Collections.Generic;

namespace Worker.Domain.Models
{
    public class Cart
    {
        public int DbId { get; set; }
        public long FeedId { get; set; }
        public string UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
