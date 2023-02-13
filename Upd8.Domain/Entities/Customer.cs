using System;
using Upd8.Domain.Core.Entities;

namespace Upd8.Domain.Entities
{
	public class Customer : Entity
	{
		public Customer(
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

        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public string Gender { get; private set; }
        public bool Active { get; private set; } 
    } 
}
