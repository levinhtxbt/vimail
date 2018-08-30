using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Core.Models;
using Newtonsoft.Json;

namespace MailChimp.Core.Core
{
    public static class Helper
    {

        public static async Task EnsureSuccessMailChimpAsync(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new MailChimpNotFoundException($"Unable to find the resource at {response.RequestMessage.RequestUri} ");
                }

                var responseContentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                throw new MailChimpException(responseContentStream.Deserialize<MailChimpApiError>(), response);
            }
        }

        public static string GetHash(this HashAlgorithm md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();
            foreach (var t in data)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }

        private static T Deserialize<T>(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var jsonSerializer = new JsonSerializer();
                return jsonSerializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
