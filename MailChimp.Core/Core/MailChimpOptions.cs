using System;
using System.Collections.Generic;
using System.Text;

namespace MailChimp.Core
{
    public class MailChimpOptions
    {
        private string _apiKey;

        private string _dataCenter;

        private string _authHeader;

        public string AuthHeader => _authHeader;

        public string ApiKey
        {
            set
            {
                _apiKey = value;
                _authHeader = $"apiKey {value}";
                _dataCenter = string.IsNullOrWhiteSpace(this.ApiKey)
                    ? string.Empty
                    : this.ApiKey.Substring(
                        this.ApiKey.LastIndexOf("-", StringComparison.Ordinal) + 1,
                        this.ApiKey.Length - this.ApiKey.LastIndexOf("-", StringComparison.Ordinal) - 1);
            }
            get => _apiKey;
        }

        public string DataCenter => _dataCenter;

    }
}
