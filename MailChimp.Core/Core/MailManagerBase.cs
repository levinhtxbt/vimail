namespace MailChimp.Core.Core
{
    public abstract class MailManagerBase
    {
        protected readonly MailChimpOptions MailChimpOptions;

        protected MailManagerBase(string apiKey) => MailChimpOptions = new MailChimpOptions
        {
            ApiKey = apiKey
        };

        protected MailManagerBase(MailChimpOptions options) => MailChimpOptions = options;

        protected MailManagerBase()
        {
        }
    }
}