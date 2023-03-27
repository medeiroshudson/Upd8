using MediatR;
using Upd8.Domain.Commons;

namespace Upd8.Application.Customer.Command;

public sealed record UpdateCustomerCommand : IRequest<Domain.Entities.Customer>
{
    public UpdateCustomerCommand(Guid id, string? name, string? document, DateTime? birthDate, Gender? gender, Address? address)
    {
        Id = id;
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
    }

    public Guid Id { get; }
    public string? Name { get; } = string.Empty;
    public string? Document { get; } = string.Empty;
    public DateTime? BirthDate { get; }
    public Gender? Gender { get; }
    public Address? Address { get; }
}
