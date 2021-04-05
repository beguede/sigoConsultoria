using System;

namespace ConsultoriasService.Application.Models
{
    public class EmpresaModel
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public bool Ativa { get; set; }
    }
}
