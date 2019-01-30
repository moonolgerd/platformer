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
        // GET api/values
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            return new Item();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item item)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
