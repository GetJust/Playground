Feature: MathFunctions
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **result** of math operations ***two*** numbers via an API

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When an API call is made to add the two numbers
	Then the API should return an HTTP OK status code
	And the result should be 120

Scenario: Subtract two numbers
	Given the first number is 70
	And the second number is 50
	When an API call is made to subtract the two numbers
	Then the API should return an HTTP OK status code
	And the result should be 20
