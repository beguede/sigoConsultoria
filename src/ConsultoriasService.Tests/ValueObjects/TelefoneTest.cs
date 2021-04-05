using ConsultoriasService.Domain.ValueObjects;
using Xunit;

namespace ConsultoriasService.Tests.ValueObjects
{
    public class TelefoneTest
    {
        [Theory]
        [InlineData(0, null)]
        [InlineData(0, "")]
        [InlineData(0, "   ")]
        [InlineData(2, "a")]
        [InlineData(10, "abcf")]
        [InlineData(99, "1234567890")]
        [InlineData(1000, "12345678a")]
        public void CriarTelefone_TelefoneInvalido_Test(int ddd, string numero)
        {
            var nome = new Telefone(ddd, numero);

            Assert.True(nome.Invalid);
            Assert.Contains(nome.Notifications, n => n.Property == nameof(Telefone.Ddd));
            Assert.Contains(nome.Notifications, n => n.Property == nameof(Telefone.Numero));
        }

        [Theory]
        [InlineData(11, "12345678")]
        [InlineData(21, "123456789")]
        [InlineData(31, "999881122")]
        public void CriarTelefone_TelefoneValido_Test(int ddd, string numero)
        {
            var nome = new Telefone(ddd, numero);

            Assert.True(nome.Valid);
        }

        [Theory]
        [InlineData(21, "123456789")]
        [InlineData(31, "999881122")]
        public void CriarTelefone_TelefoneValido_NumeroComDdd_Test(int ddd, string numero)
        {
            var telefone = new Telefone(ddd, numero);
            var valorEsperado = $"{ddd}{numero}";
            
            Assert.Equal(telefone.NumeroComDdd, valorEsperado);
            Assert.Equal(telefone.ToString(), valorEsperado);
        }
    }
}
