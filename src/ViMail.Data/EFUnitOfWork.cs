using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViMail.Data.Interfaces;

namespace ViMail.Data
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EFUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {                
                return false;
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}