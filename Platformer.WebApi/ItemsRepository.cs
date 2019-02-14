using Platformer.Shared;
using System;
using System.Collections.Generic;

namespace Platformer.WebApi
{
    public class ItemsRepository
    {
        public IEnumerable<Item> GetItems()
        {
            var items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Tanechka", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Olezhka", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Someone Else", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };
            return items;
        }

        public void Insert(Item item)
        {

        }
    }
}
