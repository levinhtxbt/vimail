using System.Threading.Tasks;

namespace ViMail.Data.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        ///     Status of changes
        /// </returns>
        bool Commit();

        /// <summary>
        ///     Asynchronously saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous save operation. The task result contains the
        ///     number of state entries written to the database.
        /// </returns>
        Task<bool> CommitAsync();
    }
}