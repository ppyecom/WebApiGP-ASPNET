using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class AddressForDelivery
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Departamento { get; set; }

    public int Provincia { get; set; }

    public int Distrito { get; set; }

    public string AddressDir { get; set; } = null!;

    public string? Referencia { get; set; }

    public string? Detalle { get; set; }
}
