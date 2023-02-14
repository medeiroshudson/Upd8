using System;
using Upd8.Domain.Entities;
using Upd8.Domain.Interfaces.Repositories;
using Upd8.Domain.Interfaces.Services;

namespace Upd8.Application.Services
{
	public class CustomerService : ICustomerService
	{
        private readonly ICustomerRepository customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
            this.customerRepository = customerRepository;
		}

        public Customer AddCustomer(Customer customer) => customerRepository.Add(customer);

        public IEnumerable<Customer> GetAllCustomers() => customerRepository.GetAll();

        public Customer? GetCustomerById(Guid id) => customerRepository.GetById(id);

        public void UpdateCustomer(Customer customer) => customerRepository.Update(customer);

        public void RemoveCustomer(Guid id) => customerRepository.Remove(id);
    }
}
