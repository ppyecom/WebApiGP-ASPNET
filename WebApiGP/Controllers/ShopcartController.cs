using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopcartController : ControllerBase
    {
        private readonly IShopcart shopcart;

        public ShopcartController(IShopcart shopcart)
        {
            this.shopcart = shopcart;
        }

        [HttpPost("addshopcart")]
        [Authorize(Roles = "Admin, Comprador")]
        public IActionResult PostShopcart(int user_id, int products_id, int quantity, string coupon)
        {
            if (quantity <= 0)
            {
                return BadRequest("Vacio");
            }

            try
            {
                shopcart.AddShopcart(user_id,products_id,quantity,coupon);
                return Ok("Producto agregado a carrito.");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("quantityshop")]
        [Authorize(Roles ="Admin ,Comprador")]
        public IActionResult UpdateQuantityShopcart(int id, int user_id, int products_id, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Vacio");
            }

            try
            {
                shopcart.UpdateShopcartQuantity(id,user_id,products_id,quantity);
                return Ok("Cantidad Actualizada");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("shopcartuser/{iduser:int}")]
        [Authorize(Roles = "Admin, Comprador")]
        public IActionResult GetShopcartsListById(int iduser)
        {
            return Ok(shopcart.GetShopcartsByUserId(iduser));
        }
    }
}
