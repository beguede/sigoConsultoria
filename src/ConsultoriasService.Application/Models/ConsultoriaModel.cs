using System;

namespace ConsultoriasService.Application.Models
{
    public class ConsultoriaModel
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid NormaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
    }
}
