using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class DeliveryMode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
