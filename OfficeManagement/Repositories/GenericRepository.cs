using Microsoft.EntityFrameworkCore;
using OfficeManagement.Data;
using System.Linq.Expressions;

namespace OfficeManagement.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate);
        Task Update(T entity);
        Task SaveChangesAsync();
        void UpdateRanage(IEnumerable<T> entities);
        Task Delete(T entity);
        IQueryable<T> FindQueryableBySql(string query);
    }

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public async Task<T> Get(int id)
        {
            return await context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return context.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).AsEnumerable();
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate);
        }

        public async Task Update(T entity)
        {
            context.Update(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void UpdateRanage(IEnumerable<T> entities)
        {
            context.UpdateRange(entities);
        }

        public async Task Delete(T entity)
        {
            context.Remove(entity);
            await SaveChangesAsync();
        }

        public IQueryable<T> FindQueryableBySql(string query)
        {
            return context.Set<T>().FromSqlRaw(query);
        }
    }
}
