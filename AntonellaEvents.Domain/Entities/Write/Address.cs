using AntonellaEvents.Domain.Validation;

namespace AntonellaEvents.Domain.Entities.EntitiesWrite
{
	public class Address : BaseEntity
	{
		public Events? Events { get; set; }
		public string ZipCode { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }
		public string? Complement { get; set; }
		public string City { get; set; }
		public string State { get; set; }

		public Address(string zipCode, string street, string number, string? complement, string city, string state) 
		{
			ValidateDomain(zipCode, street, number, complement, city, state);
			ZipCode = zipCode;
			Street = street;
			Number = number;
			Complement = complement;
			City = city;
			State = state;
		}
		private void ValidateDomain(string zipCode, string street, string number, string? complement, string city, string state)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(zipCode), "O Cep não pode ser vazio !");
			DomainExceptionValidation.When(zipCode.Length > 8, "Cep não pode conter mais que 8 caracteres !");

			DomainExceptionValidation.When(string.IsNullOrEmpty(street), "A rua não pode ser vazio !");
			DomainExceptionValidation.When(street.Length > 50, "Rua não pode conter mais que 50 caracteres !");

			DomainExceptionValidation.When(string.IsNullOrEmpty(number), "Número não pode ser vazio !");
			DomainExceptionValidation.When(number.Length > 5, "Número não pode conter mais que 5 caracteres !");
			if (complement != null) 
			{
				DomainExceptionValidation.When(string.IsNullOrEmpty(complement), "Complemento não pode ser vazio !");
				DomainExceptionValidation.When(complement.Length > 100, "Complemento não pode conter mais que 100 caracteres !");
			}
			DomainExceptionValidation.When(string.IsNullOrEmpty(city), "Cidade não pode ser vazio !");
			DomainExceptionValidation.When(city.Length > 40, "Cidade não pode conter mais que 40 caracteres !");

			DomainExceptionValidation.When(string.IsNullOrEmpty(state), "Estado não pode ser vazio !");
			DomainExceptionValidation.When(state.Length > 2, "Estado não pode conter mais que 2 caracteres !");
		}
	}
}
