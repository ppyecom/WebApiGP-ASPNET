using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class SpViewProduct
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string CodeProduct { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Price { get; set; }

    public int IsActive { get; set; }

    public int CategoriesId { get; set; }

    public int BrandsId { get; set; }

    public int Stocks { get; set; }

    public DateTime CreateAt { get; set; }
}
