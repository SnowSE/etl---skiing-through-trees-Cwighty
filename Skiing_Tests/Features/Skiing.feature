Feature: Skiing

A short summary of the feature

@tag1
Scenario: Read Tree Map
	Given a tree input file
	When parsed
	Then the file is parsed correctly

Scenario: Loop tree map
	Given a tree input line of 31 in length
	When skier moves to 2,33
	Then the skiers next location is 2,1

Scenario: Skier Moves correctly
	Given a starting location of 0,0
	When skiing a slope of 1:1
	Then the skiers next location is 1,1

	Given a starting location of 0,0
	When skiing a slope of 1:2
	Then the skiers next location is 1,2

Scenario: Skier hits a tree
	Given a tree location of 1,2
	When skier lands on 1,2
	Then the tree hit is counted


