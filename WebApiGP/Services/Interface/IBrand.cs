using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface IBrand
    {
        IEnumerable<Brand> GetBrands();
        void AddBrand(string name, string descripcion);
        void UpdateBrand(int id, string name, string descripcion);
    }
}
