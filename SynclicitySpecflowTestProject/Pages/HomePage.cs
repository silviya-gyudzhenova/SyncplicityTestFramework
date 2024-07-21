using OpenQA.Selenium;

namespace SyncplicitySpecflowTestProject.Pages
{
    public class HomePage:BasePage
    {
        public static WebDriver driver;

        By NameLabelLocator = By.Id("loginView1_liUserTitle");
        IWebElement UserAccountsTab => driver.FindElement(By.XPath("//a[contains(text(),'User Accounts')]"));

        public bool isNameLabelVisible()
        {
            IWebElement NameLabel = getWebElementAfterBeingVisible(NameLabelLocator);
            return NameLabel.Displayed;
        }

        public string getNameLabelText()
        {
            IWebElement NameLabel = driver.FindElement(NameLabelLocator);
            return NameLabel.Text;
        }

        public void clickUserAccountsTab()
        {
            UserAccountsTab.Click();
        }
    }
}
