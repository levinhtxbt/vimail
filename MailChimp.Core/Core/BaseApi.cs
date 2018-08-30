using System;
using System.Net.Http;

namespace MailChimp.Core.Core
{
    public abstract class BaseApi
    {
        internal MailChimpOptions _options;

        protected BaseApi(MailChimpOptions options)
        {
            _options = options;
        }

        protected HttpClient CreateMailClient(string resource)
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;
            }

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri($"https://{_options.DataCenter}.api.mailchimp.com/3.0/{resource}")
            };
            client.DefaultRequestHeaders.Add("Authorization", _options.AuthHeader);
            return client;
        }
    }
}