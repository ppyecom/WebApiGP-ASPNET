using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal? Gravada { get; set; }

    public decimal? Igv { get; set; }

    public decimal? TotalAmount { get; set; }

    public int Payment { get; set; }

    public int DeliveryTy { get; set; }

    public int AddressE { get; set; }

    public decimal? AmountDelivery { get; set; }

    public int StatusOrder { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual DeliveryMode DeliveryTyNavigation { get; set; } = null!;

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();

    public virtual PaymentType PaymentNavigation { get; set; } = null!;

    public virtual StatusOrder StatusOrderNavigation { get; set; } = null!;
}
