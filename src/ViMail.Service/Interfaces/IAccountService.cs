using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViMail.Service.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(string username, string password);

        Task<bool> LoginAsync(string username, string password);
    }
}
