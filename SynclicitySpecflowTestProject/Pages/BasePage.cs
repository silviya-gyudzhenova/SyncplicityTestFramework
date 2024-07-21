using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SyncplicitySpecflowTestProject.Pages
{
    public class BasePage
    {
        public static WebDriver driver;
        public BasePage() { }

        public IWebElement getWebElementAfterBeingVisible(By elementLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(elementLocator);
            });
            return webElement;
        }
    }
}
