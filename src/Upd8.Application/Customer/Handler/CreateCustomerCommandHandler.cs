using MediatR;
using Upd8.Application.Customer.Command;
using Upd8.Infra.Data;

namespace Upd8.Application.Customer.Handler;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Domain.Entities.Customer>
{
    private readonly DatabaseContext _databaseContext;
    public CreateCustomerCommandHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Domain.Entities.Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Domain.Entities.Customer.Create(request.Name, request.Document, request.BirthDate, request.Gender, request.Address);

        await _databaseContext.Customer.AddAsync(customer, cancellationToken);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return customer;
    }
}
