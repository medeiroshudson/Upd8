using System.ComponentModel.DataAnnotations;

namespace Upd8.Web.Models;

public class CustomerViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "CPF")]
    public string Document { get; set; } = string.Empty;

    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? BirthDate { get; set; }

    public Address? Address { get; set; }

    [Display(Name = "Sexo")]
    public Gender Gender { get; set; } = Gender.Unknown;
}
