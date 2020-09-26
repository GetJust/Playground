Feature: MathService
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **result** of math operations ***two*** numbers

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 70
	And the second number is 50
	When the two numbers are subtracted
	Then the result should be 20
