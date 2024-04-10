using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Active
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
