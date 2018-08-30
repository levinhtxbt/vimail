using Newtonsoft.Json;
using System.Collections.Generic;

namespace MailChimp.Core.Models
{
    public class MailChimpApiError
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("instance")]
        public string Instance { get; set; }

        [JsonProperty("errors")]
        public List<MailChimpError> Errors { get; set; } = new List<MailChimpError>();
    }

    public class MailChimpError
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}