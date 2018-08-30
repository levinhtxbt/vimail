using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Core.Implements;

namespace MailChimp.Core.Interfaces
{
    public interface IApiInfo
    {
        Task<ApiInfo> GetInfoAsync();
    }
}
