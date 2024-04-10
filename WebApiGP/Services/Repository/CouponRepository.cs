using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class CouponRepository : ICoupon
    {
        BDGP bd = new BDGP();
        public IEnumerable<Coupon> GetCoupons()
        {
            var cupons = bd.Coupons.ToList();
            return cupons;
        }
        public void AddCoupon(string code, DateTime start_date, DateTime ending_date, string description, decimal discount, int idpro)
        {
            try
            {

                bd.Database.ExecuteSqlRaw("EXEC sp_add_coupons @code, @start_date, @ending_date, @description, @discount, @products_id",
                    new SqlParameter("@code",code),
                    new SqlParameter("@start_date", start_date),
                    new SqlParameter("@ending_date", ending_date),
                    new SqlParameter("@description", description),
                    new SqlParameter("@discount", discount),
                    new SqlParameter("products_id", idpro));
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void UpdateCoupon(int id, string code, DateTime start_date, DateTime ending_date, string description, decimal discount, int idpro)
        {
            try
            {

                bd.Database.ExecuteSqlRaw("EXEC sp_update_coupons @id ,@code, @start_date, @ending_date, @description, @discount, @products_id",
                    new SqlParameter("@id", id),
                    new SqlParameter("@code", code),
                    new SqlParameter("@start_date", start_date),
                    new SqlParameter("@ending_date", ending_date),
                    new SqlParameter("@description", description),
                    new SqlParameter("@discount", discount),
                    new SqlParameter("products_id", idpro));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el Cupon" + e.Message);
            }
        }
    }
}
