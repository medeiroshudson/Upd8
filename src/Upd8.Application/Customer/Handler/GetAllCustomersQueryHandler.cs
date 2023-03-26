using MediatR;
using Upd8.Infra.Data;
using Upd8.Application.Customer.Query;
using Microsoft.EntityFrameworkCore;

namespace Upd8.Application.Customer.Handler;

public sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Domain.Entities.Customer>>
{
    private readonly DatabaseContext _databaseContext;
    public GetAllCustomersQueryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _databaseContext.Customer.ToListAsync(cancellationToken);
    }
}
