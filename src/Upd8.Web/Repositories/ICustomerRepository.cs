using Upd8.Web.Models;

namespace Upd8.Web.Repositories;

public interface ICustomerRepository
{
    List<CustomerViewModel> GetAll();
    CustomerViewModel? GetById(Guid customerId);
    void Create();
    void Update(CustomerViewModel customer);
    void Delete(Guid customerId);
}
