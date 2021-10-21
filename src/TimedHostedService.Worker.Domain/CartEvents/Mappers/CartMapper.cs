using System;
using System.Collections.Generic;
using System.Linq;
using TimedHostedService.Worker.Domain.CartEvents.Events;
using TimedHostedService.Worker.Domain.Models;
using TimedHostedService.Worker.Domain.Services;

namespace TimedHostedService.Worker.Domain.CartEvents.Mappers
{
    public class CartMapper : ICartMapper
    {
        ///<inheritdoc/>
        public IEnumerable<CartEvent> MapCartEvent(IEnumerable<EventDto> eventDtos)
        {
            var cartEvents = new List<CartEvent>();

            eventDtos
                .ToList()
                .ForEach(e => cartEvents.Add(new CartEvent()
                {
                    DateUtc = e.DateUtc,
                    EventType = GetEventType(e.EventType),
                    Id = e.Id,
                    Items = MapCartItemEvent(e.Items),
                    UserId = e.UserId
                }));

            return cartEvents;
        }

        ///<inheritdoc/>
        public Cart MapCart(CartEvent cartEvent)
        {
            var cart = new Cart()
            {
                FeedId = cartEvent.Id,
                CartItems = new List<CartItem>(),
                DateUtc = cartEvent.DateUtc,
                UserId = cartEvent.UserId
            };

            foreach (var item in cartEvent.Items)
            {
                var cartItem = new CartItem()
                {
                    FeedId = item.Id,
                    Quantity = item.Quantity,
                    UnitCost = item.UnitCost
                };

                cart.CartItems.Add(cartItem);
            }

            // TODO - figure out why sleepy Carl couldnt figure this linq foreach :D

            //cartEvent
            //    .Items
            //    .ToList()
            //    .ForEach(i => cart.CartItems.ToList().Add(new CartItem()
            //    {
            //        FeedId = i.Id,
            //        Quantity = i.Quantity,
            //        UnitCost = i.UnitCost
            //    }));

            return cart;
        }

        private EventType GetEventType(string eventType)
        {
            Enum.TryParse(eventType, out EventType et);
            return et;
        }

        private IEnumerable<Item> MapCartItemEvent(IEnumerable<ItemDto> itemDtos)
        {
            var cartItemEvent = new List<Item>();
            if (itemDtos == null)
                return cartItemEvent;

            itemDtos
                .ToList()
                .ForEach(i => cartItemEvent.Add(new Item()
                {
                    Id = i.Id,
                    Quantity = i.Quantity,
                    UnitCost = i.UnitCost
                }));

            return cartItemEvent;
        }
    }
}
