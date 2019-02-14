using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Platformer.Shared;
using System.Linq;

namespace Platformer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsRepository itemsRepository;

        public ItemsController(ItemsRepository itemsRepository) => this.itemsRepository = itemsRepository;

        // GET api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return Ok(itemsRepository.GetItems());
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
                itemsRepository.Insert(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem);
            }
        }

        // PUT api/items/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
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
