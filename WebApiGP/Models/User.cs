using System;
using System.Collections.Generic;

namespace WebApiGP.Models;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int TypeDocumentu { get; set; }

    public string NumberDocument { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public int Departamento { get; set; }

    public int Provincia { get; set; }

    public int Distrito { get; set; }

    public string Direccion { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public int IsActive { get; set; }

    public int PermissionsId { get; set; }

    public virtual Departamento DepartamentoNavigation { get; set; } = null!;

    public virtual Distrito DistritoNavigation { get; set; } = null!;

    public virtual Active IsActiveNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Permission Permissions { get; set; } = null!;

    public virtual Provincia ProvinciaNavigation { get; set; } = null!;

    public virtual ICollection<Shopcart> Shopcarts { get; set; } = new List<Shopcart>();

    public virtual TypeDocument TypeDocumentuNavigation { get; set; } = null!;
}
