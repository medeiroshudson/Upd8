using Upd8.Domain.Commons;

namespace Upd8.Domain.Entities;

public sealed class Customer : BaseEntity
{
    private Customer() { }
    private Customer(Guid id, string name, string document, DateTime? birthDate, Gender? gender, Address? address)
    {
        Id = id;
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
    }

    public string Name { get; private set; } = string.Empty;
    public string Document { get; private set; } = string.Empty;
    public DateTime? BirthDate { get; private set; }
    public Gender? Gender { get; private set; }
    public Address? Address { get; private set; }

    public static Customer Create(string name, string document, DateTime? birthDate, Gender gender, Address? address)
    {
        return new Customer(Guid.NewGuid(), name, document, birthDate, gender, address);
    }

    public void Edit(string? name, string? document, DateTime? birthDate, Gender? gender, Address? address)
    {
        Name = string.IsNullOrEmpty(name) ? this.Name : name;
        Document = string.IsNullOrEmpty(document) ? this.Document : document;
        BirthDate = birthDate ?? this.BirthDate;
        Gender = (gender != this.Gender) ? this.Gender : gender;
        Address = address ?? this.Address;

        // TODO: Disparar um evento para edição de usuário
    }
}
