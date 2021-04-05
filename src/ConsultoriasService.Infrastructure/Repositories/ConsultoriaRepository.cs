using AutoMapper;
using ConsultoriasService.Domain.Entities;
using ConsultoriasService.Domain.Repositories;
using ConsultoriasService.Infrastructure.Database;
using System.Diagnostics.CodeAnalysis;

namespace ConsultoriasService.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ConsultoriaRepository : BaseRepository<Consultoria>, IConsultoriaRepository
    {
        private readonly IMapper _mapper;
        protected readonly DatabaseContext _context;

        public ConsultoriaRepository(IMapper mapper, DatabaseContext context)
            : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
