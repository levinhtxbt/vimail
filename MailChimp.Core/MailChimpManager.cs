using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Core.Core;
using MailChimp.Core.Interfaces;

namespace MailChimp.Core
{
    public class MailChimpManager : MailManagerBase, IMailChimpManager
    {

        public MailChimpManager(string apiKey) : base(apiKey)
        {            
        }

        public MailChimpManager(MailChimpOptions options) : base(options)
        {            
        }


        public IMailChimpManager Configure(Action<MailChimpOptions> options)
        {
            options(MailChimpOptions);
            return this;
        }
    }

}
