using ConsultoriasService.Domain.ValueObjects;
using Xunit;

namespace ConsultoriasService.Tests.ValueObjects
{
    public class CPFTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("123456789123")]
        [InlineData("123456789101231")]
        [InlineData("asdfghjkloi")]
        [InlineData("1234567890a")]
        public void CriarCpf_CpfInvalido_Test(string numero)
        {
            var cpf = new CPF(numero);

            Assert.True(cpf.Invalid);
            Assert.Contains(cpf.Notifications, n => n.Property == nameof(CPF.Numero));
        }

        [Theory]
        [InlineData("12345678901")]
        [InlineData("09876543210")]
        public void CriarCpf_CpfValido_Test(string numero)
        {
            var cpf = new CPF(numero);

            Assert.True(cpf.Valid);
        }

        [Fact]
        public void CriarCpf_CpfValido_GetCopy_Test()
        {
            var cpf = new CPF("12345678901");
            var cpfClone = (CPF)cpf.GetCopy();

            Assert.Equal(cpfClone.Numero, cpf.Numero);
        }
    }
}