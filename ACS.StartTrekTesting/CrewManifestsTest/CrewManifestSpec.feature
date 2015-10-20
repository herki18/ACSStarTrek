Feature: Visting Home page

Scenario: Visit Home Page
    Given the {Crew Manifest} is open
    When the {Crew Manifest} is selected
    Then the {Crew Manifest} should be Star Trek
    And the {Add and Remove Crew} button is present
    And the {number of crew displayed} should be {number = 3}
	
