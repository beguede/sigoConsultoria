using Flunt.Validations;
using ConsultoriasService.Domain.Core.ValueObjects;

namespace ConsultoriasService.Domain.ValueObjects
{
    public class Telefone : ValueObject
    {
        public Telefone(int ddd, string numero)
        {
            Ddd = ddd;
            Numero = numero;

            AddNotifications(new Contract()
              .Requires()
              .IsGreaterOrEqualsThan(Ddd, 11, nameof(Ddd), "DDD deve estar entre 11 e 98")
              .IsLowerThan(Ddd, 99, nameof(Ddd), "DDD deve estar entre 11 e 98")
            );

            AddNotifications(new Contract()
              .Requires()
              .IsNotNullOrWhiteSpace(Numero, nameof(Numero), "Número de telefone não pode ser nulo ou branco")
              .HasMinLen(Numero, 8, nameof(Numero), "Número de telefone deve conter 8 ou 9 posições numéricas")
              .HasMaxLen(Numero, 9, nameof(Numero), "Número de telefone deve conter 8 ou 9 posições numéricas")
              .IsDigit(Numero, nameof(Numero), "Número de telefone deve conter apenas números")
            );
        }

        public int Ddd { get; private set; }
        public string Numero { get; private set; }
        public string NumeroComDdd { get { return $"{Ddd}{Numero}"; } }

        public override string ToString()
        {
            return NumeroComDdd;
        }
    }
}
