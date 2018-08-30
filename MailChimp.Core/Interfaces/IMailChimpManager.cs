using System;
using System.Collections.Generic;
using System.Text;

namespace MailChimp.Core.Interfaces
{
    public  interface IMailChimpManager
    {
        IApi Api { get; set; }
    }
}
