Feature: Localization
	In cas I don't know English language
	As a potential Customer
	I want to read Navigation item in Different languages

Scenario: Change language
	Given Home Page opened
	When <language> language chosen
	Then Check <language> navigation item are displayed

	Examples:
	 | language | 
	 | en-En    | 
	 | de-De    |