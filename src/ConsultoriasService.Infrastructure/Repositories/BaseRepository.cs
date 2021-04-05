using Microsoft.EntityFrameworkCore;
using ConsultoriasService.Domain.Repositories;
using ConsultoriasService.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace ConsultoriasService.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Incluir(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Guid id)
        {
            var item = await ObterPorId(id);

            if (item != null)
            {
                _context.Set<TEntity>().Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<TEntity>> ListarTodos()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
