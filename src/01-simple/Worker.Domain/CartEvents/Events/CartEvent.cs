using System;
using System.Collections.Generic;

namespace Worker.Domain.CartEvents.Events
{
    public class CartEvent
    {
        public long Id { get; set; }

        public EventType EventType { get; set; }

        public string UserId { get; set; }

        public DateTime DateUtc { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
