using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SyncplicitySpecflowTestProject.Entities;
using SyncplicitySpecflowTestProject.Pages;
using TechTalk.SpecFlow.Assist;

namespace SymplicitySpecflowTestProject.StepDefinitions
{
    [Binding]
    public class SyncplicityLoginStepDefinitions
    {
        public static readonly string PATH = "https://eu.syncplicity.com";

        LoginPage LoginPage => new LoginPage();
        HomePage HomePage => new HomePage();

        [BeforeScenario]
        public static void BeforeScenario()
        {
            ChromeDriver currentDriver = new ChromeDriver();
            BasePage.driver = currentDriver;
            LoginPage.driver = currentDriver;
            HomePage.driver = currentDriver;
            ManageUsersPage.driver = currentDriver;
        }

        [Given(@"The user opens ""(.*)""")]
        public void GivenTheUserOpens(string urlAddress)
        {
            LoginPage.openTheLoginPage(urlAddress);
        }

        [Given(@"The user logs in with the following credentials:")]
        public void GivenTheUserLogsInWithTheFollowingCredentials(Table table)
        {
            UserCredentials userCredentials = table.CreateInstance<UserCredentials>();
            GivenTheUserOpens(PATH);
            WhenTheUserFillsTheEmailFieldWith(userCredentials.Email);
            WhenTheUserClicksOnNextButton();
            WhenTheUserFillsThePasswordFieldWith(userCredentials.Password);
            WhenTheUserClicksOnLogInButton();
            ThenTheUserSeesTheLabelWithHisNameAndItIsNotEmpty();
        }

        [When(@"The user fills the Email field with ""(.*)""")]
        public void WhenTheUserFillsTheEmailFieldWith(string email)
        {
            LoginPage.fillEmailField(email);
        }

        [When(@"The user clicks on Next button")]
        public void WhenTheUserClicksOnNextButton()
        {
            LoginPage.clickNextButton();
        }

        [When(@"The user fills the Password field with ""(.*)""")]
        public void WhenTheUserFillsThePasswordFieldWith(string password)
        {
            LoginPage.fillPasswordField(password);
        }

        [When(@"The user clicks on Log in button")]
        public void WhenTheUserClicksOnLogInButton()
        {
            LoginPage.clickLogInButton();
        }

        [Then(@"The user sees the label with his name and it is not empty")]
        public void ThenTheUserSeesTheLabelWithHisNameAndItIsNotEmpty()
        {
            Assert.IsTrue(HomePage.isNameLabelVisible(), "The Name Label is not visible!");
            Assert.AreNotEqual("", HomePage.getNameLabelText(), "The Name Label is empty!");
        }

        [Then(@"Error message with text ""(.*)"" is displayed")]
        public void ThenErrorMessageWithTextIsDisplayed(string errorMeassage)
        {
            Assert.AreEqual(errorMeassage, LoginPage.getEmailErrorMessage(), "The actual error message is not equal to " + errorMeassage);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            LoginPage.driver.Close();
        }

    }
}
