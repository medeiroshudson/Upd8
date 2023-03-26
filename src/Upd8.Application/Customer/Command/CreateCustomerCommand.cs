using MediatR;
using Upd8.Domain.Commons;

namespace Upd8.Application.Customer.Command;

public sealed record CreateCustomerCommand : IRequest<Domain.Entities.Customer>
{
    public CreateCustomerCommand(string name, string document, DateTime? birthDate, Gender gender, Address? address)
    {
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
    }

    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; } = Gender.Unknown;
    public Address? Address { get; set; }
}
