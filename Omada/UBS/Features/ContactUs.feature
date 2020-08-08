Feature: ContactUs form
	In order to contact with UBS company
	As a potential Customer
	I want to fill ContactUs form

Scenario: Fill Contact Us form and send
	Given Domiciles 'Asia Pacific' 'China' picked
	And 'Contact' page displayed
	When I fill Contact Us form
	Then I can send it to UBS company