using System;

namespace MailChimp.Core.Core
{
    public class MailChimpNotFoundException : Exception
    {
        public MailChimpNotFoundException(string message) : base(message)
        {
        }
    }
}