using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface IShopcart
    {
        IEnumerable<Shopcart> GetShopcartsByUserId(int userId);
        void AddShopcart(int user_id, int products_id, int quantity, string coupon);
        void UpdateShopcartQuantity(int id, int user_id, int products_id, int quantity);
    }
}
