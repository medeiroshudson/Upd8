using MediatR;

namespace Upd8.Application.Customer.Query;

public sealed record GetAllCustomersQuery : IRequest<List<Domain.Entities.Customer>>;
