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
    public class OrderController : ControllerBase
    {
        private readonly IOrder order;

        public OrderController(IOrder order)
        {
            this.order = order;
        }

        [HttpGet("ordenes")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetOrdenes()
        {
            return Ok(order.GetOrders());
        }

        [HttpGet("ordenesbyiduser/{id:int}")]
        [Authorize(Roles = "Admin, Comprador")]
        public IActionResult GetOrdenesById(int id) { 
            return Ok(order.GetOrderById(id));
        }

        [HttpPost("agregarorder")]
        [Authorize(Roles = "Comprador")]
        public IActionResult AddOrden(int user_id, int payment, int delivery_ty, int addressE)
        {
            if (user_id <= 0 || payment <= 0 || delivery_ty <= 0 || addressE <= 0)
            {
                return BadRequest("Vacio.");
            }

            try
            {
                order.AddOrder(user_id,payment,delivery_ty,addressE);
                return Ok("Orden agregada");
            }catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
