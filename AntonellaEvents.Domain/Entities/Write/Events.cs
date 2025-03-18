using AntonellaEvents.Domain.Validation;

namespace AntonellaEvents.Domain.Entities.Write
{
	public class Events : BaseEntity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public bool IsPublic { get; private set; }
		public Address? Address { get; private set; }
		public int AddressId { get; private set; }
		public Events(string name, string description, DateTime startDate, DateTime endDate, bool isPublic, int addressId)
		{
			ValidateDomain(name, description, startDate, endDate, addressId);
			Name = name;
			Description = description;
			StartDate = startDate;
			EndDate = endDate;
			IsPublic = isPublic;
			AddressId = addressId;
		}

		private void ValidateDomain(string name, string description, DateTime startDate, DateTime endDate, int addressId)
		{
			DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "O nome do evento não pode ser vazio!");
			DomainExceptionValidation.When(name.Length > 100, "O nome do evento não pode conter mais que 100 caracteres!");

			DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "A descrição do evento não pode ser vazia!");
			DomainExceptionValidation.When(description.Length > 500, "A descrição do evento não pode conter mais que 500 caracteres!");

			DomainExceptionValidation.When(startDate == default, "A data de início do evento é inválida!");
			DomainExceptionValidation.When(endDate == default, "A data de término do evento é inválida!");
			DomainExceptionValidation.When(startDate >= endDate, "A data de início deve ser menor que a data de término!");

			DomainExceptionValidation.When(startDate < DateTime.Now.AddHours(8), "O evento deve ser criado com pelo menos 8 horas de antecedência!");

			DomainExceptionValidation.When(addressId <= 0, "O endereço do evento é obrigatório!");
		}
		public void SetAddress(int adressId)
		{
			AddressId = adressId;
		}
	}
}
