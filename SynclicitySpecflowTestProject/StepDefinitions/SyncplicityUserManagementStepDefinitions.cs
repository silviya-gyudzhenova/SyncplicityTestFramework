using NUnit.Framework;
using SyncplicitySpecflowTestProject.Pages;

namespace SyncplicitySpecflowTestProject.StepDefinitions
{
    [Binding]
    public class SyncplicityUserManagementStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        HomePage HomePage => new HomePage();
        ManageUsersPage ManageUsersPage => new ManageUsersPage();
        public SyncplicityUserManagementStepDefinitions(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }
        [When(@"The user clicks on User Accounts tab")]
        public void WhenTheUserClicksOnUserAccountsTab()
        {
            HomePage.clickUserAccountsTab();
        }

        [When(@"The user clicks on Add a User button")]
        public void WhenTheUserClicksOnAddAUserButton()
        {
            Thread.Sleep(2000);
            ManageUsersPage.clickAddAUserButton();
        }

        [When(@"The user fills Email Addresses field and the user saves the email address as ""(.*)""")]
        public void WhenTheUserFillsEmailAddressesFieldAndTheUserSavesTheEmailAddressAs(string emailAddressKey)
        {
            String emailAddress = getRandomString(10) + "@dispostable.com";
            ManageUsersPage.FillEmailAddressesField(emailAddress);
            _scenarioContext.Add(emailAddressKey, emailAddress);
        }

        [When(@"The user selects ""(.*)"" role")]
        public void WhenTheUserSelectsRole(string role)
        {
            ManageUsersPage.clickRoleDropDown();
            ManageUsersPage.selectRole(role);
        }

        [When(@"The user clicks on Next button on the page with email address")]
        public void WhenTheUserClicksOnNextButtonOnThePageWithEmailAddress()
        {
            ManageUsersPage.clickNextButtonAfterFillingEmailAddress();
        }

        [When(@"The user clicks on Next button on Group Membership page")]
        public void WhenTheUserClicksOnNextButtonOnGroupMembershipPage()
        {
            ManageUsersPage.clickNextButtonGroupMembership();
        }

        [When(@"The user clicks on Next button on User Folders page")]
        public void WhenTheUserClicksOnNextButtonOnUserFoldersPage()
        {
            ManageUsersPage.clickNextButtonUserFolders();
        }

        [When(@"The user clicks on View and edit existing users link")]
        public void WhenTheUserClicksOnViewAndEditExistingUsersLink()
        {
            ManageUsersPage.clickViewAndEditExistingUsersLink();
        }

        [When(@"The user clicks on ""(.*)"" email")]
        public void WhenTheUserClicksOnEmail(string emailAddressKey)
        {
            String emailAddress = _scenarioContext.Get<string>(emailAddressKey);
            ManageUsersPage.clickSpecificEmailAddress(emailAddress);
        }

        [When(@"The user searches for ""(.*)""")]
        public void WhenTheUserSearchesFor(string emailAddressKey)
        {
            String emailAddress = _scenarioContext.Get<String>(emailAddressKey);
            ManageUsersPage.fillSearchField(emailAddress);
            ManageUsersPage.clickSearchIcon();

        }

        [Then(@"The user sees ""(.*)"" link")]
        public void ThenTheUserSeesLink(string emailAddressKey)
        {
            String emailAddress = _scenarioContext.Get<string>(emailAddressKey);
            Assert.True(ManageUsersPage.isSpecificEmailAddressVisible(emailAddress), "The email address " + emailAddress + "is not visible!");
        }

        [Then(@"The user sees the message with text ""(.*)""")]
        public void ThenTheUserSeesTheMessageWithText(string congratulationsMessage)
        {
            Assert.AreEqual(congratulationsMessage, ManageUsersPage.getCongratulationsText(), "The Congratulations Text is not equal to " + congratulationsMessage + "!");
        }

        [Then(@"The user sees that the role is ""(.*)""")]
        public void ThenTheUserSeesThatTheRoleIs(string role)
        {
            Assert.AreEqual(role, ManageUsersPage.getRolePropertyText(), "The role is not equal to " + role + "!");
        }

        private String getRandomString(int stringLength)
        {
            String chars = "abcdefghijklmnopqrstuvwxyz";
            char[] stringChars = new char[stringLength];
            Random random = new Random();

            for (int i=0; i<stringLength; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            String finalString = new String(stringChars);
            return finalString;
        }
    }
}
