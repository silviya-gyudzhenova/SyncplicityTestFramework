Feature: Syncplycity Log In functionality
This feature is for testing Log In Functionality of Syncplicity Web Site


Scenario: Log in with valid credentials
	Given The user opens "https://eu.syncplicity.com"
	When The user fills the Email field with "syncplicity-technical-interview@dispostable.com"
	And The user clicks on Next button
	And The user fills the Password field with "s7ncplicit@Y"
	And The user clicks on Log in button
	Then The user sees the label with his name and it is not empty

Scenario: Log in with invalid email
	Given The user opens "https://eu.syncplicity.com"
	When The user fills the Email field with "syncplicity-applicant"
	And The user clicks on Next button
	Then Error message with text "Please enter a valid email address." is displayed