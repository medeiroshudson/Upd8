using MediatR;
using Upd8.Application.Customer.Command;
using Upd8.Infra.Data;

namespace Upd8.Application.Customer.Handler;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Domain.Customer.Customer>
{
    private readonly DatabaseContext _databaseContext;
    public CreateCustomerCommandHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Domain.Customer.Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _databaseContext.Customer.AddAsync(request.Customer, cancellationToken);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return request.Customer;
    }
}
