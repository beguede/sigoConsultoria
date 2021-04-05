using Flunt.Validations;
using ConsultoriasService.Domain.Core.ValueObjects;

namespace ConsultoriasService.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(PrimeiroNome, nameof(Nome.PrimeiroNome), "Primeiro nome não pode ser nulo ou branco")
                .IsNotNullOrWhiteSpace(Sobrenome, nameof(Nome.Sobrenome), "Sobrenome não pode ser nulo ou branco")
                .HasMinLen(PrimeiroNome, 2, nameof(Nome.PrimeiroNome), "Primeiro nome deve conter pelo menos 2 caracteres")
                .HasMinLen(Sobrenome, 2, nameof(Nome.Sobrenome), "Sobrenome deve conter pelo menos 2 caracteres"));
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }
        public string NomeCompleto { get { return $"{PrimeiroNome} {Sobrenome}"; } }

        public override string ToString()
        {
            return NomeCompleto;
        }
    }
}