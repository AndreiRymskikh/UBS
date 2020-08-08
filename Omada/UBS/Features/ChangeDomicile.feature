Feature: Change Domicile
	In order to read info about UBS
	As a potential Customer
	I want to change domiciles and read info about the company

Scenario: Add two numbers
	Given Home Page opened
	When domiciles choosen <continent>, <country>
	Then I can read <title> info about the company

	Examples:
	 | continent     | country | title   |
	 | Europe        | Austria | Austria |
	 | North America | Canada  | Canada        |