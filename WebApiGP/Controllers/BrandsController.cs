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
    public class BrandsController : ControllerBase
    {
        private readonly IBrand brand;
        public BrandsController(IBrand brand)
        {
            this.brand = brand;
        }

        [HttpGet("brands")]
        [Authorize(Roles = "Admin, Comprador")]
        public IActionResult GetBrands()
        {
            return Ok(brand.GetBrands());
        }

        [HttpPost("addbrand")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBrandAdm(string name, string descripcion)
        {
            if (name==null && descripcion == null)
            {
                return BadRequest("La Marca no debe estar vacia");
            }

            try
            {
                brand.AddBrand(name,descripcion);
                return Ok("Marca Registrada");
            }catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("updateBrand")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditBrandAdm(int id, string name, string descripcion) {
        
            if (id <= 0 && name == null && descripcion == null)
            {
                return BadRequest("La Marca no debe estar vacia");
            }

            try
            {
                brand.UpdateBrand(id, name, descripcion);
                return Ok("Marca Actualizada");
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
