using Microsoft.EntityFrameworkCore;
using projetoXYZ.Context;
using projetoXYZ.Context.Interfaces;
using projetoXYZ.Interfaces.IRepositories.IBaseRepository;
using System.Diagnostics.Contracts;

namespace projetoXYZ.Repository.BaseRepository
{
    public class BaseRepository<T>
        : IDisposable, IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _context = unitOfWork as AppDbContext;
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.Save();
        }
        public async Task Update(T entity)
        {
            await Task.Run(() => _context.Entry(entity).State = EntityState.Modified);
            await _context.Save();
        }
        public async Task Delete(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
            await _context.Save();
        }
        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);
        public void Dispose() => _context.Dispose();
    }
}
