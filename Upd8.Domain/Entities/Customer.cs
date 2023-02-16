using Upd8.Domain.Core.Entities;

namespace Upd8.Domain.Entities
{
    public class Customer : Entity
	{
		public Customer(
            Guid id, string name, string document, DateTime birthDate,
            string gender, string city, string state, string country, bool? active)
		{
            Id = id;
            Name = name;
            Document = document;
            BirthDate = birthDate;
            Gender = gender;
            City = city;
            State = state;
            Country = country;
            Active = active;
		}

        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public bool? Active { get; private set; } = true;
    } 
}
