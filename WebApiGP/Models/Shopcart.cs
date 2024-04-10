using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Shopcart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductsId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public int? Coupon { get; set; }

    public decimal? Discount { get; set; }

    public decimal Total { get; set; }

    public DateTime DateShop { get; set; }

    public int IsActive { get; set; }

    public virtual Coupon? CouponNavigation { get; set; }

    public virtual Product Products { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
