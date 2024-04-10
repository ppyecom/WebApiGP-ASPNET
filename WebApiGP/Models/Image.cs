using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Image
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int ProductId { get; set; }

    public int ImageOrder { get; set; }

    public virtual Product Product { get; set; } = null!;
}
