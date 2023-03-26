using MediatR;
using Upd8.Domain.Commons;

namespace Upd8.Application.Customer.Command;

public sealed class CreateCustomerCommand : IRequest<Domain.Customer.Customer>
{
    public Domain.Customer.Customer Customer { get; set; } = null!;
}
