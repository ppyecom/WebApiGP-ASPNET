using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class SpViewBrand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int IsActive { get; set; }
}
