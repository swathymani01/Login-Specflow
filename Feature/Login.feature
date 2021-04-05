Feature: Login fearue

Scenario Outline: login feature
	Given Open login Page
	When Enter <Organisation>,<Login> and <Password>
	Then User should login successfully
	Examples: 
	| Organisation  | Login              | Password |
	| Demo Practice | specflow_challenge | Test1234 |