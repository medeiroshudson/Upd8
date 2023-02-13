using System;

namespace Upd8.Domain.Entities
{
	public class Customer
	{
		private Customer(
            Guid id, string name, string document,
            DateTime birthDate, Address address, string gender, bool active)
		{
            Id = id;
            Name = name;
            Document = document;
            BirthDate = birthDate;
            Address = address;
            Gender = gender;
            Active = active;
		}

		public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public string Gender { get; private set; }
        public bool Active { get; private set; } 

        public static Customer Create(
            Guid id, string name, string document,
            DateTime birthDate, Address address, string gender, bool active)
        {
            var customer = new Customer(
                    id: Guid.NewGuid(),
                    name: name,
                    document: document,
                    birthDate: birthDate,
                    address: address,
                    gender: gender,
                    active: active
                );

            return customer;
        }
    } 
}
