Feature: Look through location
In order to look through locations of UBS's officies
as a potential Customer 
I want to see the map of officies

Scenario: When I open Location page the map is appeared
         Given Location page opened
         When Header 'Locations' is displayed
         Then I can see the map
