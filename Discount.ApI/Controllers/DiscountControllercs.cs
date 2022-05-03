
using Discount.ApI.Entities;
using Discount.ApI.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace Discount.ApI.Controllers
{


        [Route("api/[controller]")]
        [ApiController]
        public class DiscountController : ControllerBase
        { 
            readonly IDiscountRepository  _discountRepository;
            public DiscountController(IDiscountRepository discountRepository)
            {
                _discountRepository=discountRepository;
            }


            // GET api/<BasketController>/5
            [HttpGet("{ProductName}")]
            public ActionResult<Coupon> Get(string ProductName)
            {
                return Ok(_discountRepository.getDiscount(ProductName).Result);
            }

            // POST api/<BasketController>
            [HttpPost]
            public ActionResult<Coupon> Post([FromBody] Coupon Coupon)
            {
                return Ok(_discountRepository.insert(Coupon));

            }

            // DELETE api/<BasketController>/5
            [HttpDelete("{ProductName}")]
            public ActionResult<bool> Delete(string ProductName)
            {
                return Ok(_discountRepository.delete(ProductName).Result);

            }
        // DELETE api/<BasketController>/5
        [HttpPut]
        public ActionResult<Coupon> Update([FromBody] Coupon Coupon)
        {
            return Ok(_discountRepository.update(Coupon).Result);

        }
    }
}



