using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class PaymentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
