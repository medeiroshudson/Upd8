using MediatR;
using Upd8.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Upd8.Application.Customer.Command;

namespace Upd8.Application.Customer.Handler;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Domain.Entities.Customer>
{
    private readonly DatabaseContext _databaseContext;
    public UpdateCustomerCommandHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Domain.Entities.Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _databaseContext.Customer
            .Where(customer => customer.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (customer is null)
            throw new KeyNotFoundException();

        customer.Edit(
            request.Name, request.Document, request.BirthDate, request.Gender, request.Address
        );

        _databaseContext.Customer.Update(customer);
        _databaseContext.SaveChanges();

        return customer;
    }
}
