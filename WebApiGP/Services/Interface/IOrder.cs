using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface IOrder
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrderById(int id);
        void AddOrder(int user_id, int payment, int delivery_ty, int addressE);
    }
}
