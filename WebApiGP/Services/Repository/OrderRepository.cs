using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class OrderRepository : IOrder
    {
        BDGP bd = new BDGP();
        public void AddOrder(int user_id, int payment, int delivery_ty, int addressE)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_order @user_id, @payment, @delivery_ty, @addressE",
                    new SqlParameter("@user_id", user_id),
                    new SqlParameter("@payment", payment),
                    new SqlParameter("@delivery_ty", delivery_ty),
                    new SqlParameter("@addressE", addressE));
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Order> GetOrderById(int id)
        {
            var orders = bd.Orders.Where(o => o.CustomerId == id).ToList();
            return orders;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = bd.Orders.ToList();
            return orders;
        }
    }
}
