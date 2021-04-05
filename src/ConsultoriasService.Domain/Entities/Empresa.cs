using ConsultoriasService.Domain.Core.Entities;
using System;

namespace ConsultoriasService.Domain.Entities
{
    public class Empresa : Entity, IAggregateRoot
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public bool Ativa { get; set; }
    }
}
