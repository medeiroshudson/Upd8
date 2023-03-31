using System.ComponentModel.DataAnnotations;

namespace Upd8.Web.Models;

[Display(Name = "Endereço")]
public class Address
{

    [Display(Name = "Rua")]
    public string? StreetName { get; set; }

    [Display(Name = "Cidade")]
    public string? City { get; set; }

    [Display(Name = "Estado")]
    public string? State { get; set; }

    [Display(Name = "País")]
    public string? Country { get; set; }
}
