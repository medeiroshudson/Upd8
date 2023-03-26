using Upd8.Domain.Commons;

namespace Upd8.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; init; } = string.Empty;
    public string Document { get; init; } = string.Empty;
    public Address Address { get; init; } = null!;
}
