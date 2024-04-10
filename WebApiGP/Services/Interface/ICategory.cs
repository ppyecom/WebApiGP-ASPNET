using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(string name, string descripcion);
        void UpdateCategory(int id, string name, string descripcion);
    }
}
