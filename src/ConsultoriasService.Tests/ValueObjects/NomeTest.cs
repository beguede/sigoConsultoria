using ConsultoriasService.Domain.ValueObjects;
using Xunit;

namespace ConsultoriasService.Tests.ValueObjects
{
    public class NomeTest
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("   ", "   ")]
        [InlineData("a", "a")]
        [InlineData("x", "")]
        [InlineData("", "z")]
        public void CriarNome_NomeInvalido_Test(string primeiroNome, string sobrenome)
        {
            var nome = new Nome(primeiroNome, sobrenome);

            Assert.True(nome.Invalid);
            Assert.Contains(nome.Notifications, n => n.Property == nameof(Nome.PrimeiroNome));
            Assert.Contains(nome.Notifications, n => n.Property == nameof(Nome.Sobrenome));
        }

        [Theory]
        [InlineData("João", "Silva")]
        [InlineData("Maria", "Couto")]
        [InlineData("carlos", "souza")]
        public void CriarNome_NomeValido_Test(string primeiroNome, string sobrenome)
        {
            var nome = new Nome(primeiroNome, sobrenome);

            Assert.True(nome.Valid);
        }

        [Theory]
        [InlineData("Maria", "Couto")]
        [InlineData("Carlos", "Souza")]
        public void CriarNome_NomeValido_NomeCompleto_Test(string primeiroNome, string sobrenome)
        {
            var nome = new Nome(primeiroNome, sobrenome);
            var valorEsperado = $"{primeiroNome} {sobrenome}";

            Assert.Equal(nome.NomeCompleto, valorEsperado);
            Assert.Equal(nome.ToString(), valorEsperado);
        }
    }
}
