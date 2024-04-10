using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Services.Repository
{
    public class BrandRepository : IBrand
    {
        BDGP bd = new BDGP();
        public IEnumerable<Brand> GetBrands()
        {
            var marcas = bd.Brands.ToList();
            return marcas;
        }
        public void AddBrand(string name, string descripcion)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_add_brands @name, @description",
                    new SqlParameter("@name", name),
                    new SqlParameter("@description", descripcion));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateBrand(int id, string name, string descripcion)
        {
            try
            {
                bd.Database.ExecuteSqlRaw("EXEC sp_update_brands @id, @name, @description",
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
