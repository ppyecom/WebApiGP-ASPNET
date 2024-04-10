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
    public class CouponController : ControllerBase
    {
        private readonly ICoupon coupon;

        public CouponController(ICoupon coupon)
        {
            this.coupon = coupon;
        }

        [HttpGet("cupones")]
        [Authorize(Roles = "Admin, Comprador")]
        public IActionResult GetCoupons() { 
            return Ok(coupon.GetCoupons());
        }
        [HttpPost("addcupon")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCoupons(string code, DateTime start_date, DateTime ending_date, string description, decimal discount, int idpro)
        {
            if (code == null || start_date <= DateTime.UtcNow || ending_date <= start_date || description == null)
            {
                return BadRequest("Cupon Vacio");
            }

            try
            {
                coupon.AddCoupon(code, start_date, ending_date, description, discount, idpro);
                return Ok("Cupon Registrado");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updatecupon")]
        [Authorize(Roles ="Admin")]
        public IActionResult EditCoupon(int id, string code, DateTime start_date, DateTime ending_date, string description, decimal discount, int idpro) { 
            if (id <=0 ||code == null || start_date <= DateTime.UtcNow || ending_date <= start_date || description == null)
            {
                return BadRequest("Cupon Vacio");
            }

            try
            {
                coupon.UpdateCoupon(id, code, start_date, ending_date, description, discount, idpro);
                return Ok("Cupon Actualizado");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
