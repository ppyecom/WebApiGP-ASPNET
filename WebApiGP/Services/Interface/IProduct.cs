using WebApiGP.Models;

namespace WebApiGP.Services.Interface
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(int userId, string codeProduct, string name, string description, decimal price, int categoriesId, int brandsId, int stocks);
        void UpdateProduct(int productId, string codeProduct, string name, string description, decimal price, int isActive, int categoriesId, int brandsId, int stocks);
    }
}



//var products = bd.Products.FromSql("SELECT * FROM sp_view_products").ToList();