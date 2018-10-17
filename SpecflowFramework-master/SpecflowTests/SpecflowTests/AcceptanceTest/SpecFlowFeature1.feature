Feature: Indicate Happiness
	In order inform individual and team happiness levels
	As a team member
	I want to be able to select and submit my happiness level details

@mytag
Scenario Outline: Submit Hapiness Information
	Given I have entered happiness levels <Emotion>
	When I press on the submit button 
	Then the hapiness level information should be submitted 

	Examples: 
	| Emotion       |
	| NotAtAllHappy |
	| NotSoHappy    |
	| Neutral       |
	| Happy         |
	| VeryHappy     |

