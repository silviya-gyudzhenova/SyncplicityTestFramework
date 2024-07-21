Feature: Syncplicity User Management Functionality
This feature is for testing User Management Functionality

Scenario: Create valid user
	Given The user logs in with the following credentials:
		| Email                                           | Password     |
		| syncplicity-technical-interview@dispostable.com | s7ncplicit@Y |
	When The user clicks on User Accounts tab
	And The user clicks on Add a User button
	And The user fills Email Addresses field and the user saves the email address as "User Email Address"
	And The user selects "Global Administrator" role
	And The user clicks on Next button on the page with email address
	And The user clicks on Next button on Group Membership page
	And The user clicks on Next button on User Folders page
	Then The user sees the message with text "User accounts successfully created"
	When The user clicks on View and edit existing users link
	And The user searches for "User Email Address"
	Then The user sees "User Email Address" link
	When The user clicks on "User Email Address" email
	Then The user sees that the role is "Global Administrator"