using MediatR;
using Microsoft.EntityFrameworkCore;
using Upd8.Application.Customer.Command;
using Upd8.Infra.Data;

namespace Upd8.Application.Customer.Handler;

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly DatabaseContext _databaseContext;
    public DeleteCustomerCommandHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await Task.Run(async () =>
        {
            var customer = await _databaseContext.Customer.FindAsync(request.CustomerId);

            if (customer is null)
                throw new KeyNotFoundException();

            customer.Delete();

            _databaseContext.Customer.Remove(customer);
            _databaseContext.SaveChanges();
        }, cancellationToken);
    }
}
