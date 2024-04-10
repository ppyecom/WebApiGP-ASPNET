using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface ICoupon
    {
        IEnumerable<Coupon> GetCoupons();
        void AddCoupon(string code, DateTime start_date, DateTime ending_date, string description, decimal discount, int idpro);
        void UpdateCoupon(int id, string code, DateTime start_date, DateTime ending_date, string description, decimal discount, int idpro);
    }
}
