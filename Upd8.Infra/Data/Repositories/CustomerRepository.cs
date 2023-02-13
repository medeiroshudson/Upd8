using System;
using Microsoft.EntityFrameworkCore;
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

        public void Add(Customer customer)
        {
            try
            {
                dbContext.Customer.Add(customer);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Customer customer)
        {
            try
            {
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
                dbContext.Entry(customer).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
