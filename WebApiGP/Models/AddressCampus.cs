using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class AddressCampus
{
    public int Id { get; set; }

    public int Departamento { get; set; }

    public int Provincia { get; set; }

    public int Distrito { get; set; }

    public string? AddressDir { get; set; }
}
