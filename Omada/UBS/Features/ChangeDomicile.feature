Feature: Change Domicile
	In order to read info about UBS
	As a potential Customer
	I want to change domiciles and read info about the company

Scenario: Change Domicile and check that pages opened as expected
	Given Home Page opened
	When domiciles choosen <region>, <country>
	Then I can read <title> info about the company

	Examples:
	 | region        | country | title   |
	 | Europe        | Austria | Austria |
	 | North America | Canada  | Canada  |