using System.Threading.Tasks;
using ViMail.Data.Entities;

namespace ViMail.Service.Interfaces
{
    public interface IEmailService
    {
         Task<Email> Create(Email email);
    }
}