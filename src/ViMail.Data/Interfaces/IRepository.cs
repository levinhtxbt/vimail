using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;

namespace ViMail.Data.Interfaces
{
    public interface IRepository<T, K> : IDisposable where T : class
    {
        /*********************** Sync method ***********************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T GetById(K id, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T GetById(K id, string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T GetSingle(Expression<Func<T, bool>> predicate, string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> Get(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> Get(string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> Find(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> Find(string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void Add(ICollection<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void Update(ICollection<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void AddOrUpdate(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void AddOrUpdate(ICollection<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Remove(K id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void Remove(ICollection<T> entities);

        /// <summary>
        ///     Returns the number of elements in a sequence.
        /// </summary>
        /// <returns>
        ///     The number of elements in the input sequence.
        /// </returns>
        int Count();

        /// <summary>
        ///     Returns the number of elements in the specified sequence that satisfies a condition.
        /// </summary>
        /// <param name="predicate">
        ///     A function to test each element for a condition.
        /// </param>
        /// <returns>
        ///     The number of elements in the sequence that satisfies the condition in the predicate function.
        /// </returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        decimal Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector);

        /// <summary>
        ///     Determines whether a sequence contains a specified element by using the default equality comparer.
        /// </summary>
        /// <param name="item">The object to locate in the sequence.</param>
        /// <returns>
        ///     true if the input sequence contains an element that has the specified value; otherwise, false.
        /// </returns>
        bool Contains(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="SP"></typeparam>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<SP> ExecuteStoredProcedure<SP>(string sp, DynamicParameters parameters);


        /************************************************************/

        /*********************** Async method ***********************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(K id, string[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, string[] includeProperties);

        /// <summary>
        ///    Asynchronously returns the number of elements in a sequence.
        /// </summary>
        /// <param name="predicate"> A function to test each element for a condition. </param>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains the number of elements in the input sequence.
        /// </returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///     each element of the input sequence.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains the sum of the projected values..
        /// </returns>
        Task<decimal> SumAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector);

        /// <summary>
        ///     Asynchronously determines whether a sequence contains a specified element by using the default equality comparer.
        /// </summary>
        /// <param name="item">The object to locate in the sequence.</param>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains <c>true</c> if the input sequence contains the specified value; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> ContainsAsync(T item);        


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="SP"></typeparam>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<SP>> ExecuteStoredProcedureAsync<SP>(string sp, DynamicParameters parameters);

        /************************************************************/
    }
}