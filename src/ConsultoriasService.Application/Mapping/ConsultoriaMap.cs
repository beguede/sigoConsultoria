using AutoMapper;
using ConsultoriasService.Application.Models;
using ConsultoriasService.Domain.Entities;

namespace ConsultoriasService.Application.Mapping
{
    public class ConsultoriaMap : Profile
    {
        public ConsultoriaMap()
        {
            CreateMap<Consultoria, ConsultoriaModel>();

            CreateMap<ConsultoriaModel, Consultoria>();
        }
    }
}
