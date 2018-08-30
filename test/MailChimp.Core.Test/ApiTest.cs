using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailChimp.Core.Test
{
    [TestClass]
    public class ApiTest : MailChimpTest
    {
        [TestMethod]
        public async Task Should_Return_API_Information()
        {
            var apiInfo = await this.MailChimpManager.Api.GetInfoAsync().ConfigureAwait(false);
            Assert.IsNotNull(apiInfo);
        }
    }
}
