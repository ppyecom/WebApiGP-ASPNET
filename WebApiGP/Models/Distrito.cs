using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Distrito
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdProvincia { get; set; }

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
