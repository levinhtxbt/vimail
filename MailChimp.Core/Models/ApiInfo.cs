using Newtonsoft.Json;

namespace MailChimp.Core.Models
{
    public class ApiInfo
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("login_id")]
        public string LoginId { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("member_since")]
        public string MemberSince { get; set; }

        [JsonProperty("pricing_plan_type")]
        public string PricingPlanType { get; set; }

        [JsonProperty("first_payment")]
        public string FirstPayment { get; set; }

        [JsonProperty("account_timezone")]
        public string AccountTimezone { get; set; }

        [JsonProperty("account_industry")]
        public string AccountIndustry { get; set; }

        [JsonProperty("pro_enabled")]
        public bool ProEnabled { get; set; }

        [JsonProperty("industry_stats")]
        public IndustryStats IndustryStats { get; set; }

        [JsonProperty("contact")]
        public ApiContact Contact { get; set; }

        [JsonProperty("last_login")]
        public string LastLogin { get; set; }

        [JsonProperty("_links")]
        public Link[] Links { get; set; }

        [JsonProperty("total_subscribers")]
        public int TotalSubscribers { get; set; }
    }
}