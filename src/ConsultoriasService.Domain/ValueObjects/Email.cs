using Flunt.Validations;
using ConsultoriasService.Domain.Core.ValueObjects;

namespace ConsultoriasService.Domain.ValueObjects
{
    public class Email : ValueObject
    {        
        public Email(string endereco)
        {
            Endereco  = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Endereco, nameof(Email.Endereco), "Email não pode ser nulo ou branco")
                .IsEmail(Endereco, nameof(Email.Endereco), "Email inválido"));
        }

        public string Endereco { get; private set; }

        public override string ToString()
        {
            return Endereco;
        }
    }
}