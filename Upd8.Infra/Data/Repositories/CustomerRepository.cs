using Upd8.Domain.Entities;
using Upd8.Domain.Interfaces.Repositories;

namespace Upd8.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
	{
		private readonly DatabaseContext dbContext;

		public CustomerRepository(DatabaseContext dbContext)
		{
			this.dbContext = dbContext;
		}

        public IEnumerable<Customer> GetAll() => dbContext.Customer.ToList();

        public Customer? GetById(Guid id) => dbContext.Customer.Find(id);

        public Customer Add(Customer customer)
        {
            try
            {
                var created = dbContext.Customer.Add(customer);
                dbContext.SaveChanges();

                return created.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Guid id)
        {
            try
            {
                var customer = GetById(id);

                if (customer == null)
                    return;

                dbContext.Customer.Remove(customer);
                dbContext.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                dbContext.Customer.Update(customer);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
