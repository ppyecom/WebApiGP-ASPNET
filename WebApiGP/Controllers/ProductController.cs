using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("Api/Product")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProduct product;
        public ProductController(IProduct product)
        {
            this.product = product;
        }
        [HttpGet("productos")]
        [Authorize(Roles = "Admin,Comprador")]
        public IActionResult Get()
        {
            return Ok(product.GetProducts());
        }
        [HttpPost("addproduct")]
        [Authorize(Roles = "Admin")]
        public IActionResult PostProduct(int userId, string codeProduct, string name, string description, decimal price, int categoriesId, int brandsId, int stocks) {
            if (codeProduct == null || name == null || description == null || price <= 0 || stocks <= 0)
            {
                return BadRequest("El producto no puede ser nulo");
            }

            try
            {
                product.AddProduct(userId,codeProduct,name,description,price,categoriesId,brandsId,stocks);
                return Ok("Producto agregado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar el producto: {ex.Message}");
            }
        }
        [HttpPut("updateproduct")]
        [Authorize(Roles = "Admin,Comprador")]
        public IActionResult PutProduct(int productId, string codeProduct, string name, string description, decimal price, int isActive, int categoriesId, int brandsId, int stocks)
        {
            if (codeProduct == null || name == null || description == null || price <= 0)
            {
                return BadRequest("El producto actualizado no puede ser nulo");
            }

            try
            {
                product.UpdateProduct(productId,codeProduct,name,description,price,isActive,categoriesId,brandsId,stocks);
                return Ok("Producto actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el producto: {ex.Message}");
            }
        }
    }
}
