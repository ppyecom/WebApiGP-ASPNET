using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
