using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViMail.Data.Entities;
using ViMail.Data.Interfaces;

namespace ViMail.Data
{
    public class EFRepository<T, K> : IRepository<T, K> where T : DomainEntry<K>
    {
        #region Fields

        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        #endregion Fields

        #region Ctor

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            if (_dbContext != null)
                _dbSet = _dbContext.Set<T>();
        }

        #endregion Ctor

        public IDbConnection GetConnection()
        {
            var configuration = _dbContext.GetService<IConfiguration>();
            if (configuration != null)
            {
                var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
                //var connectionString = configuration.GetConnectionString("DefaultConnection");

                return new SqlConnection(connectionString);
            }

            throw new NullReferenceException();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public T GetById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T GetById(K id, string[] includeProperties)
        {
            return Get(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(includeProperties).SingleOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, string[] includeProperties)
        {
            return Get(includeProperties).SingleOrDefault(predicate);
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> Get(string[] includeProperties)
        {
            IQueryable<T> items = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dbSet.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, string[] includeProperties)
        {
            IQueryable<T> items = _dbSet.Where(predicate);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IEnumerable<T> Find(params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(includeProperties).ToList();
        }

        public IEnumerable<T> Find(string[] includeProperties)
        {
            return Get(includeProperties).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(predicate, includeProperties).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, string[] includeProperties)
        {
            return Get(predicate, includeProperties).ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(ICollection<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(ICollection<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void AddOrUpdate(T entity)
        {
            if (entity.IsTransient)
            {
                Add(entity);
            }
            else
            {
                Update(entity);
            }
        }

        public void AddOrUpdate(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                AddOrUpdate(entity);
            }
        }

        public void Remove(K id)
        {
            Remove(GetById(id));
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(ICollection<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Get(predicate).Count(predicate);
        }

        public decimal Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector)
        {
            return Get(predicate).Sum(selector);
        }

        public bool Contains(T t)
        {
            return _dbSet.Contains(t);
        }

        public async Task<IEnumerable<T>> FindAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await Get(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(string[] includeProperties)
        {
            return await Get(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Get(predicate, includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string[] includeProperties)
        {
            return await Get(predicate, includeProperties).ToListAsync();
        }

        public async Task<T> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Get(includeProperties).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> GetByIdAsync(K id, string[] includeProperties)
        {
            return await Get(includeProperties).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Get(includeProperties).SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, string[] includeProperties)
        {
            return await Get(includeProperties).SingleOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get(predicate).CountAsync();
        }

        public async Task<decimal> SumAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector)
        {
            return await Get(predicate).SumAsync(selector);
        }

        public async Task<bool> ContainsAsync(T t)
        {
            return await _dbSet.ContainsAsync(t);
        }

        public IEnumerable<TSp> ExecuteStoredProcedure<TSp>(string sp, DynamicParameters parameters)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<TSp>(sp, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TSp>> ExecuteStoredProcedureAsync<TSp>(string sp, DynamicParameters parameters)
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<TSp>(sp, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}