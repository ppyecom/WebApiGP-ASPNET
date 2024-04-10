using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Product
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

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();

    public virtual ICollection<Shopcart> Shopcarts { get; set; } = new List<Shopcart>();
}
