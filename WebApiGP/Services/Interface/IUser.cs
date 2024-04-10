using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface IUser
    {
        User GetUserAdmin(string user1, string pass1);
        void AddUser(string firstNameParam, string lastNameParam, string usernameParam, string passwordParam, string emailParam, int typeDocumentuParam,
            string numberDocumentParam, string telephoneParam, int departamentoParam, int provinciaParam, int distritoParam, string direccionParam);
        void UpdateUser(string userIdParam, string firstNameParam, string lastNameParam, string emailParam, string telephoneParam, int departamentoParam, int provinciaParam,
            int distritoParam, string direccionParam);
    }
}
