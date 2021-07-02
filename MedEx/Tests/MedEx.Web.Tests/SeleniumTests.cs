using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace MedEx.Web.Tests
{
    public class SeleniumTests : IClassFixture<SeleniumServerFactory<Startup>>, IDisposable
    {
        private readonly SeleniumServerFactory<Startup> server;
        private readonly IWebDriver browser;

        public SeleniumTests(SeleniumServerFactory<Startup> server)
        {
            this.server = server;
            server.CreateClient();
            var opts = new ChromeOptions();
            opts.AddArguments("--headless");
            opts.AcceptInsecureCertificates = true;
            browser = new ChromeDriver(opts);
        }

        [Fact(Skip = "Example test. Disabled for CI.")]
        public void FooterOfThePageContainsPrivacyLink()
        {
            browser.Navigate().GoToUrl(server.RootUri);
            Assert.EndsWith(
                "/Home/Privacy",
                browser.FindElements(By.CssSelector("footer a")).First().GetAttribute("href"));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                server?.Dispose();
                browser?.Dispose();
            }
        }
    }
}
