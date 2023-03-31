using Upd8.Web.Models;

namespace Upd8.Web.Repositories.Backend.Customer;

public interface ICustomerRepository
{
    Task<List<CustomerViewModel>> GetAllAsync();
    Task<CustomerViewModel?> GetByIdAsync(Guid customerId);
    Task CreateAsync(CustomerViewModel customer);
    Task UpdateAsync(CustomerViewModel customer);
    Task DeleteAsync(Guid customerId);
}
