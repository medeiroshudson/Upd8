using MediatR;
namespace Upd8.Application.Customer.Command;

public sealed record CreateCustomerCommand : IRequest<Domain.Customer.Customer>
{
    public Domain.Customer.Customer Customer { get; set; } = null!;
}
