using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class Provincia
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
