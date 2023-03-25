using Upd8.Domain.Commons;

namespace Upd8.Domain.Customer;

public class Customer : BaseEntity
{
    public string Name { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public Address? Address { get; }
}
