using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class CategoryRepository : ICategory
    {
        BDGP bd = new BDGP();

        public IEnumerable<Category> GetCategories()
        {
            var categorias = bd.Categories.ToList();
            return categorias;
        }
        public void AddCategory(string name, string descripcion)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_categories @name, @description",
                    new SqlParameter("@name", name),
                    new SqlParameter("@description", descripcion));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateCategory(int id,string name, string descripcion)
        {
            try
            {

                bd.Database.ExecuteSqlRaw("EXEC sp_update_categories @id, @name, @description",
                    new SqlParameter("@id", id),
                    new SqlParameter("@name", name),
                    new SqlParameter("@description", descripcion));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
