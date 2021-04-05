using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsultoriasService.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace ConsultoriasService.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class EmpresaDbMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESAS");

            builder.HasKey(c => c.Id)
                .HasName("PK_EMPRESAS");

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL");

            builder.Property(c => c.NomeFantasia)
                .HasColumnName("NOMEFANTASIA");

            builder.Property(c => c.CNPJ)
                .HasColumnName("CNPJ");

            builder.Property(c => c.Ativa)
                .HasColumnName("ATIVA");
        }
    }
}
