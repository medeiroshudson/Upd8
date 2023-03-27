using MediatR;

namespace Upd8.Application.Customer.Command;

public sealed record DeleteCustomerCommand(Guid CustomerId) : IRequest;