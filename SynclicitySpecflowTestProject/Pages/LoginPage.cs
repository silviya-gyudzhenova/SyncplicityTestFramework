using OpenQA.Selenium;

namespace SyncplicitySpecflowTestProject.Pages
{
    public class LoginPage:BasePage
    {
        public static WebDriver driver;

        public IWebElement EmailField => driver.FindElement(By.Id("MainContent_login_UserName"));
        public IWebElement NextButton => driver.FindElement(By.Id("MainContent_login_btnNext"));
        public By PasswordFieldLocator => By.Id("MainContent_login_txtPassword");
        public IWebElement LogInButton => driver.FindElement(By.Id("MainContent_login_btnLogin"));
        public IWebElement EmailInvalidMessage => driver.FindElement(By.Id("MainContent_login_UserName-error"));

        public LoginPage()
        {
        }

        public void openTheLoginPage(string url)
        {
            driver.Url = url;
            driver.Navigate();
            driver.Manage().Window.Maximize();
        }

        public void fillEmailField(string email)
        {
            EmailField.SendKeys(email);    
        }

        public void clickNextButton()
        {
            NextButton.Click();
        }

        public void fillPasswordField(string password)
        {
            IWebElement PasswordField = getWebElementAfterBeingVisible(PasswordFieldLocator);
            PasswordField.SendKeys(password);
        }

        public void clickLogInButton()
        {
            LogInButton.Click(); 
        }

        public String getEmailErrorMessage()
        {
            return EmailInvalidMessage.Text;
        }
    }
}
