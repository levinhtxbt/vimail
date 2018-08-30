using MailChimp.Core.Core;
using MailChimp.Core.Implements;
using MailChimp.Core.Interfaces;
using System;

namespace MailChimp.Core
{
    public class MailChimpManager : MailManagerBase, IMailChimpManager
    {
        #region Ctor

        public MailChimpManager(string apiKey) : base(apiKey)
        {
            this.Api = new Api(MailChimpOptions);
        }

        public MailChimpManager(MailChimpOptions options) : base(options)
        {
            this.Api = new Api(MailChimpOptions);
        }

        #endregion Ctor

        #region Configure

        public IMailChimpManager Configure(Action<MailChimpOptions> options)
        {
            options(MailChimpOptions);
            return this;
        }

        #endregion Configure

        public IApi Api { get; set; }
    }
}