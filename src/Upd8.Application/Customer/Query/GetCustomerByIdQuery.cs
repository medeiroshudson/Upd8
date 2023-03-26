using MediatR;

namespace Upd8.Application.Customer.Query;

public sealed record GetCustomerByIdQuery(Guid CustomerId) : IRequest<Domain.Entities.Customer>;
