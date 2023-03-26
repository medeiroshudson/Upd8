using MediatR;
namespace Upd8.Application.Customer.Command;

public sealed record CreateCustomerCommand : IRequest<Domain.Entities.Customer>
{
    public Domain.Entities.Customer Customer { get; set; } = null!;
}
