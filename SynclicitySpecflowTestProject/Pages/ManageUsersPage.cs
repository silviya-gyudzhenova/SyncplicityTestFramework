using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SyncplicitySpecflowTestProject.Pages
{
    public class ManageUsersPage:BasePage
    {
        public static WebDriver driver = BasePage.driver;
        private static WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        public IWebElement AddAUserButton => driver.FindElement(By.XPath("//div[@id='divForMainContentPlaceHolder']/a[@href='AddUser.aspx#users']"));
        public IWebElement EmailAddressesField => driver.FindElement(By.Id("txtUserEmails"));
        public IWebElement RoleDropdown => driver.FindElement(By.Id("roleselectdropdownbutton"));
        public IWebElement NextButtonUserEmails => driver.FindElement(By.Id("nextButtonUserEmails"));
        public IWebElement NextButtonGroupMembership => driver.FindElement(By.Id("nextButtonGroupMembership"));
        public IWebElement NextButtonUserFolders => driver.FindElement(By.Id("nextButtonUserFolders"));
        public IWebElement CongratulationsMessage => driver.FindElement(By.CssSelector("#divForMainContentPlaceHolder > div.container-wrap.content-box.bottom-only > div > div > div > div > div.WizardStep.Congratulations > h2"));
        public IWebElement ViewAndEditExistingUsersLink => driver.FindElement(By.LinkText("View and edit existing users"));
        public IWebElement RoleProperty => driver.FindElement(By.XPath("//span[@class='user-property']"));
        public IWebElement SearchField => driver.FindElement(By.CssSelector(".jqfilter-input-email"));
        public IWebElement SearchIcon => driver.FindElement(By.CssSelector(".jqfilter-search-email-wrapper.js-changed.multi-wrapper > i"));
        public ManageUsersPage()
        {
        }

        public void clickAddAUserButton()
        {
            AddAUserButton.Click();
        }

        public void FillEmailAddressesField(String emailAddress)
        {
            EmailAddressesField.SendKeys(emailAddress);
        }

        public void clickRoleDropDown()
        {
            RoleDropdown.Click();
        }

        public void selectRole(string role)
        {
            IWebElement SpecificRole = driver.FindElement(By.XPath("//li[contains(text(), '" + role + "')]"));
            SpecificRole.Click();
        }

        public void clickNextButtonAfterFillingEmailAddress()
        {
            NextButtonUserEmails.Click(); 
        }

        public void clickNextButtonGroupMembership()
        {
            Thread.Sleep(2000);
            NextButtonGroupMembership.Click();
        }

        public void clickNextButtonUserFolders()
        {
            NextButtonUserFolders.Click();
        }

        public void clickViewAndEditExistingUsersLink()
        {
            ViewAndEditExistingUsersLink.Click();
        }
        
        public void clickSpecificEmailAddress(string emailAddress)
        {
            IWebElement specificEmailLink = driver.FindElements(By.LinkText(emailAddress))[0];
            specificEmailLink.Click();
        }

        public void fillSearchField(string emailAddress)
        {
            SearchField.SendKeys(emailAddress);
        }

        public void clickSearchIcon() { 
            SearchIcon.Click();
        }

        public bool isSpecificEmailAddressVisible(string emailAddress)
        {
            Thread.Sleep(1000);
            IWebElement specificEmailLink = driver.FindElement(By.XPath($"(//a[contains(.,'{emailAddress}')])[1]"));
            return specificEmailLink.Displayed;
        }

        public String getCongratulationsText()
        {
            String congratulationsText = CongratulationsMessage.Text;

            for (int i = 0; i < 10; i++)
            {
                if (!String.IsNullOrEmpty(congratulationsText))
                {
                    break;
                }
                else
                {
                    Thread.Sleep(500);
                    congratulationsText = CongratulationsMessage.Text;
                }
            }
            return congratulationsText;
        }

        public string getRolePropertyText()
        {
            return RoleProperty.Text;
        }
    }
}
