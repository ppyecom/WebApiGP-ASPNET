using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Coupon
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndingDate { get; set; }

    public string Description { get; set; } = null!;

    public decimal Discount { get; set; }

    public int IsActive { get; set; }

    public int ProductsId { get; set; }

    public virtual Active IsActiveNavigation { get; set; } = null!;

    public virtual Product Products { get; set; } = null!;

    public virtual ICollection<Shopcart> Shopcarts { get; set; } = new List<Shopcart>();
}
