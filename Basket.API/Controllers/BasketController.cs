using Basket.API.Entities;
using Basket.API.IServices;
using Basket.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IShopingCartService _shopingCartService;
       public BasketController(IShopingCartService shopingCartService)
        {
            _shopingCartService=shopingCartService;

        }
        
        // GET: api/<BasketController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<BasketController>/5
        [HttpGet("{UserName}")]
        public ActionResult<ShoppingCart> Get(string UserName)
        {
            return Ok( _shopingCartService.GetShopingCart(UserName));
        }

        // POST api/<BasketController>
        [HttpPost]
        public ActionResult<ShoppingCart> Post([FromBody] ShoppingCart shoppingCart)
        {
            return Ok(_shopingCartService.SetShopingCart(shoppingCart));

        }

        // DELETE api/<BasketController>/5
        [HttpDelete("{UserName}")]
        public ActionResult<ShoppingCart> Delete(string UserName)
        {
            return Ok(_shopingCartService.RemoveShopingCart(UserName));

        }
    }
}
