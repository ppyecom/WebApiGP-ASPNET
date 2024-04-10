using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class OrdersDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ShopcartId { get; set; }

    public int ProductId { get; set; }

    public decimal? PriceUnit { get; set; }

    public int Quantity { get; set; }

    public decimal? Subtotal { get; set; }

    public int? CouponId { get; set; }

    public decimal? Discount { get; set; }

    public decimal Gravada { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
