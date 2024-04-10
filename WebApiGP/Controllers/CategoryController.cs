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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;

        public CategoryController(ICategory category)
        {
            this.category = category;
        }

        [HttpGet("categorias")]
        [Authorize(Roles ="Admin, Comprador")]
        public IActionResult GetCategorias() { 
            return Ok(category.GetCategories());
        }

        [HttpPost("addcategoria")]
        [Authorize(Roles ="Admin")]
        public IActionResult AddCategory(string name, string descripcion) { 
            if (name == null || descripcion == null)
            {
                return BadRequest("Categorias vacia");
            }

            try
            {
                category.AddCategory(name, descripcion);
                return Ok("Categoria Agregada");
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updateCategoria")]
        [Authorize(Roles ="Admin")]
        public IActionResult EditCategory(int id, string name, string descripcion)
        {
            if (id <= 0 || name == null || descripcion == null)
            {
                return BadRequest("Categoria Vacias");
            }

            try
            {
                category.UpdateCategory(id,name,descripcion);
                return Ok("Categoria Actualizada");
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
