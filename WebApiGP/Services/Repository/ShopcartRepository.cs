using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class ShopcartRepository : IShopcart
    {
        BDGP bd = new BDGP();

        public IEnumerable<Shopcart> GetShopcartsByUserId(int userId)
        {
            var carrito = bd.Shopcarts.Where(s => s.UserId == userId).ToList();
            return carrito;
        }
        public void AddShopcart(int user_id, int products_id, int quantity, string coupon)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_shopcart @user_id, @products_id, @quantity, @coupon",
                    new SqlParameter("@user_id", user_id),
                    new SqlParameter("@products_id", products_id),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@coupon", coupon));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el producto: " + ex.Message);
            }
        }

        public void UpdateShopcartQuantity(int id, int user_id, int products_id, int quantity)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_shopcart @id, @user_id, @products_id, @quantity",
                    new SqlParameter("@id", id),
                    new SqlParameter("@user_id", user_id),
                    new SqlParameter("@products_id", products_id),
                    new SqlParameter("@quantity", quantity));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el producto: " + ex.Message);
            }
        }
    }
}
