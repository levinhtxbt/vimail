using MailChimp.Core.Core;
using MailChimp.Core.Interfaces;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MailChimp.Core.Test
{
    public class MailChimpTest
    {
        protected IMailChimpManager MailChimpManager;

        public MailChimpTest()
        {
            this.MailChimpManager = new MailChimpManager("681548ad94563c86a0af62bfdd183f44-us19");
            RunBeforeTestFixture().Wait();
        }

        internal virtual Task RunBeforeTestFixture()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// The hash.
        /// </summary>
        /// <param name="emailAddress">
        /// The email address.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal string Hash(string emailAddress)
        {
            using (var md5 = MD5.Create()) return md5.GetHash(emailAddress);
        }
    }
}