using ConsultoriasService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace ConsultoriasService.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ConsultoriaDbMap : IEntityTypeConfiguration<Consultoria>
    {
        public void Configure(EntityTypeBuilder<Consultoria> builder)
        {
            builder.ToTable("CONSULTORIAS");

            builder.HasKey(c => c.Id)
                .HasName("PK_CONSULTORIAS");

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(c => c.EmpresaId)
                .HasColumnName("EMPRESAID");

            builder.Property(c => c.NormaId)
                .HasColumnName("NORMAID");

            builder.Property(c => c.DataInicio)
                .HasColumnName("DATAINICIO");

            builder.Property(c => c.DataFim)
                .HasColumnName("DATAFIM");

            builder.Property(c => c.Situacao)
                .HasColumnName("SITUACAO");

            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO");
        }
    }
}
