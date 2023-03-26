using Upd8.Domain.Commons;

namespace Upd8.Domain.Entities;

public sealed class Customer : BaseEntity
{
    private Customer() { }
    private Customer(Guid id, string name, string document, DateTime? birthDate, Gender gender, Address? address)
    {
        Id = id;
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
    }

    public string Name { get; init; } = string.Empty;
    public string Document { get; init; } = string.Empty;
    public DateTime? BirthDate { get; init; }
    public Gender Gender { get; init; } = Gender.Unknown;
    public Address? Address { get; init; }

    public static Customer Create(string name, string document, DateTime? birthDate, Gender gender, Address? address)
    {
        return new Customer(Guid.NewGuid(), name, document, birthDate, gender, address);
    }
}
