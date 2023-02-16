namespace Upd8.Domain.Core.Entities
{
    public abstract class Entity
	{
		public Guid Id { get; protected set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
