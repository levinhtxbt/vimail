using MailChimp.Core.Implements;
using System.Threading.Tasks;

namespace MailChimp.Core.Interfaces
{
    public interface IApi
    {
        Task<Api> GetInfoAsync();
    }
}