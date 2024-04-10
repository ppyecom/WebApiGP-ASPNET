using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class UserRepository : IUser
    {
        BDGP bd = new BDGP();

        public void AddUser(string firstNameParam, string lastNameParam, string usernameParam, string passwordParam, string emailParam, int typeDocumentuParam,
            string numberDocumentParam, string telephoneParam, int departamentoParam, int provinciaParam, int distritoParam, string direccionParam)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_users @firstname, @lastname, @username, @passwordUser, @email, " +
                    "@type_documentu, @number_document, @telephone, @departamento, @provincia, @distrito, @direccion",
                    firstNameParam, lastNameParam, usernameParam, passwordParam, emailParam, typeDocumentuParam,
                    numberDocumentParam, telephoneParam, departamentoParam, provinciaParam, distritoParam, direccionParam);

                Console.WriteLine("Usuario agregado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el usuario: " + ex.Message);
            }
        }

        public User GetUserAdmin(string user1, string pass1)
        {
            var usuario = bd.Users.FirstOrDefault(us => us.Username == user1);

            if (usuario != null)
            {
                // Verificar la contraseña utilizando la función de verificación
                try
                {
                    if (pass1 == usuario.PasswordUser)
                    {
                        return usuario;
                    }
                    else {
                        usuario = null;
                        return usuario;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error al decodificar la cadena Base64: " + ex.Message);
                }

            }

            usuario = null;
            return usuario;
        }

        public void UpdateUser(string userIdParam,string firstNameParam, string lastNameParam,string emailParam,string telephoneParam, int departamentoParam, int provinciaParam, 
            int distritoParam, string direccionParam)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_update_user @user_id, @firstname, @lastname, @email, @telephone, " +
                    "@departamento, @provincia, @distrito, @direccion",
                    userIdParam, firstNameParam, lastNameParam, emailParam, telephoneParam,
                    departamentoParam, provinciaParam, distritoParam, direccionParam);

                Console.WriteLine("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el usuario: " + ex.Message);
            }
        }
    }
}
