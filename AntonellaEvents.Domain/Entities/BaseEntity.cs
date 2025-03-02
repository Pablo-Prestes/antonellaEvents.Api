using System;
using System.ComponentModel.DataAnnotations;

namespace AntonellaEvents.Domain.Entities
{
	public abstract class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		public Guid Uuid { get; protected set; } 

		[Required]
		public DateTime CreatedAt { get; protected set; }

		[MaxLength(40)]
		public string? UserRegistered { get; protected set; }

		[MaxLength(40)]
		public string? UserUpdated { get; protected set; }

		[MaxLength(40)]
		public string? UsuarioDeletou { get; protected set; }
		public bool Active { get; protected set; }
		public DateTime? Updated { get; protected set; }
		public DateTime? Deleted { get; protected set; }
		public void Post(string usuarioCadastrouId)
		{
			Uuid = Guid.NewGuid();
			UserRegistered = usuarioCadastrouId;
			CreatedAt = DateTime.Now;
			Active = true;
		}

		public void Update(string usuarioAtualizouId)
		{
			UserUpdated = usuarioAtualizouId;
			Updated = DateTime.Now;
		}

		public void Delete(string usuarioDeletouId)
		{
			UsuarioDeletou = usuarioDeletouId;
			Deleted = DateTime.Now;
			Active = false;
		}
	}
}
