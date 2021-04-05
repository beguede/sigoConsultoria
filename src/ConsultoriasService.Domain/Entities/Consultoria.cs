using ConsultoriasService.Domain.Core.Entities;
using System;

namespace ConsultoriasService.Domain.Entities
{
    public class Consultoria : Entity, IAggregateRoot
    {
        public Guid EmpresaId { get; set; }
        public Guid NormaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
    }
}
