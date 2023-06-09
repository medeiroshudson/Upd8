﻿using System;
using Upd8.Domain.Entities;

namespace Upd8.Domain.Interfaces.Services
{
	public interface ICustomerService
	{
		IEnumerable<Customer> GetAllCustomers();
		Customer? GetCustomerById(Guid id);
        Customer AddCustomer(Customer customer);
		void UpdateCustomer(Customer customer);
		void RemoveCustomer(Guid id);
	}
}
