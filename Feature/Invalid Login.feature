Feature: Invalid Login
	
Scenario Outline: Login feature-Invalid credentials
	Given Open login Page
	When Enter <Organisation>,<Login> and <Password>
	Then User should failed to login

	Examples: 
	|Organisation|Login    |Password|
    |Demo        |Specflow |Test    |