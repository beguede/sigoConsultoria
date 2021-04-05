using AutoMapper;
using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;

namespace ConsultoriasService.Application.Mapping
{
    public class EmpresaMap : Profile
    {
        public EmpresaMap()
        {
            CreateMap<Empresa, EmpresaModel>();

            CreateMap<EmpresaModel, Empresa>();
        }
    }
}
