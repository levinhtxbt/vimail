using MailChimp.Core.Core;
using MailChimp.Core.Extensions;
using MailChimp.Core.Interfaces;
using System.Threading.Tasks;

namespace MailChimp.Core.Implements
{
    public class Api : BaseApi, IApi
    {
        public Api(MailChimpOptions options) : base(options)
        {
        }

        public async Task<Api> GetInfoAsync()
        {
            using (var client = CreateMailClient(string.Empty))
            {
                var response = await client.GetAsync(string.Empty).ConfigureAwait(false);
                await response.EnsureSuccessMailChimpAsync().ConfigureAwait(false);

                return await response.Content.ReadAsAsync<Api>().ConfigureAwait(false);
            }
        }
    }
}