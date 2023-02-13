using System;
namespace Upd8.Domain.Entities
{
	public class Address
	{
		public Address(string city, string state, string country)
		{
			City = city;
			State = state;
            Country = country;
		}

        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
    }
}

