using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGP.Services.Interface;

namespace WebApiGP.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpPost("adduser")]
        [Authorize(Roles = "Comprador")]
        public IActionResult AgregarUsuario(string firstNameParam, string lastNameParam, string usernameParam, string passwordParam, string emailParam, int typeDocumentuParam,
            string numberDocumentParam, string telephoneParam, int departamentoParam, int provinciaParam, int distritoParam, string direccionParam)
        {
            if (firstNameParam == null || lastNameParam == null || usernameParam == null || passwordParam == null || emailParam == null || numberDocumentParam == null ||
                telephoneParam == null || direccionParam == null) {
                return BadRequest("Vacio.");

            }

            try
            {
                user.AddUser(firstNameParam, lastNameParam, usernameParam, passwordParam, emailParam, typeDocumentuParam, numberDocumentParam, telephoneParam, departamentoParam,
                    provinciaParam, distritoParam, direccionParam);
                return Ok("Usuario Agregado");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updateuser")]
        [Authorize(Roles ="Comprador")]
        public IActionResult ActualizarUsuario(string userIdParam, string firstNameParam, string lastNameParam, string emailParam, string telephoneParam, int departamentoParam, int provinciaParam,
            int distritoParam, string direccionParam)
        {
            if (firstNameParam == null || lastNameParam == null || emailParam == null || telephoneParam == null || direccionParam == null)
            {
                return BadRequest("Vacio.");

            }

            try
            {
                user.UpdateUser(userIdParam, firstNameParam, lastNameParam, emailParam, telephoneParam, departamentoParam, provinciaParam, distritoParam, direccionParam);
                return Ok("Usuario Actualizado.");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
