using MediatR;
using Upd8.Infra.Data;
using Upd8.Application.Customer.Query;
using Microsoft.EntityFrameworkCore;

namespace Upd8.Application.Customer.Handler;

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Domain.Customer.Customer?>
{
    private readonly DatabaseContext _databaseContext;
    public GetCustomerByIdQueryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Domain.Customer.Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _databaseContext.Customer
            .Where(customer => customer.Id == request.CustomerId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
