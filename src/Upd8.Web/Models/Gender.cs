using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Upd8.Web.Models;

public enum Gender
{
    [Display(Name = "Masculino")]
    Male = 0,

    [Display(Name = "Femenino")]
    Female = 1,

    [Display(Name = "Desconhecido")]
    Unknown = 2
}

public static class GenderExtensions {
    public static string? GetDisplayName(this Gender value) {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
    }
}