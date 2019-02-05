using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Platformer.Shared;
using System.Linq;

namespace Platformer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // GET api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            var items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Tanechka", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Olezhka", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Someone Else", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };
            items.AddRange(from item in mockItems
                           select item);
            return items;
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(string id)
        {
            return new Item()
            {
                Id = id
            };
        }

        // POST api/items
        [HttpPost]
        public IActionResult Post(Item item)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem);
            }
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, Item item)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem);
            }
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
