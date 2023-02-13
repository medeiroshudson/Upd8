using System;
using Upd8.Domain.Entities;

namespace Upd8.Domain.Interfaces.Repositories
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();
		Customer? GetById(Guid id);
		void Add(Customer customer);
		void Update(Customer customer);
		void Remove(Guid id);
	}
}
