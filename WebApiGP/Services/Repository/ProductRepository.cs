using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class ProductRepository : IProduct
    {

        BDGP bd = new BDGP();

        public void AddProduct(int userId, string codeProduct, string name, string description, decimal price, int categoriesId, int brandsId, int stocks)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_products @user_id, @code_product, @name, @description, @price, @categories_id, @brands_id, @stocks",
                    new SqlParameter("@user_id", userId),
                    new SqlParameter("@code_product", codeProduct),
                    new SqlParameter("@name", name),
                    new SqlParameter("@description", description),
                    new SqlParameter("@price", price),
                    new SqlParameter("@categories_id", categoriesId),
                    new SqlParameter("@brands_id", brandsId),
                    new SqlParameter("@stocks", stocks));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el producto: " + ex.Message);
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            var productos = bd.Products.ToList();
            return productos;
        }

        public void UpdateProduct(int productId, string codeProduct, string name, string description, decimal price, int isActive,int categoriesId, int brandsId, int stocks)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_update_products @id, @code_product, @name, @descripcion, @price, @is_active, @categories_id, @brands_id, @stocks",
                    new SqlParameter("@id", productId),
                    new SqlParameter("@code_product", codeProduct),
                    new SqlParameter("@name", name),
                    new SqlParameter("@descripcion", description),
                    new SqlParameter("@price", price),
                    new SqlParameter("@is_active", isActive),
                    new SqlParameter("@categories_id", categoriesId),
                    new SqlParameter("@brands_id", brandsId),
                    new SqlParameter("@stocks", stocks));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el producto: " + ex.Message);
            }
        }
    }
}
