using Upd8.Web.Models;

namespace Upd8.Web.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public List<CustomerViewModel> _data = new() {
        new CustomerViewModel() { Id = Guid.Parse("78bbec27-7664-4c29-8bb9-ad6ed7558bb3"), Name = "Robson", Document = "1234", BirthDate = DateTime.Now, Gender = Gender.Male, Address = new Address { StreetName = "Rua 1" } },
        new CustomerViewModel() { Id = Guid.Parse("a3682ab6-c903-4520-8600-e84e07d6919c"), Name = "Ailton", Document = "5678", BirthDate = DateTime.Now, Gender = Gender.Unknown }
    };

    public void Create()
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid customerId)
    {

    }

    public List<CustomerViewModel> GetAll()
    {
        return _data;
    }

    public CustomerViewModel? GetById(Guid customerId)
    {
        return _data.Find(x => x.Id == customerId);
    }

    public void Update(CustomerViewModel customer)
    {

    }
}
