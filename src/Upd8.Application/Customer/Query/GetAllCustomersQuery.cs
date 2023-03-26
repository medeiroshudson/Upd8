using MediatR;

namespace Upd8.Application.Customer.Query;

public sealed class GetAllCustomersQuery : IRequest<List<Domain.Customer.Customer>>
{
}
