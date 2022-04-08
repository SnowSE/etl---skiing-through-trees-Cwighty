Feature: Skiing

A short summary of the feature

@ReadMap
Scenario: Read Tree Map
	Given a ski slope map
	When parsed
	Then the file is parsed correctly

@LoopMap
Scenario: Loop tree map
	Given a ski slope map
	When parsed
	Given a ski slope of 6
	When skiing
	Then the skiers next location is 1,1

@Correct
Scenario: Skier Moves correctly
	Given a ski slope map
	When parsed
	Given a ski slope of 1
	When skiing
	Then the skiers next location is 1,1

@MoreCorrect
Scenario: Skier Moves Differently Correctly 
	Given a ski slope map
	When parsed
	Given a ski slope of 2
	When skiing
	Then the skiers next location is 2,1

@Collision
Scenario: Skier hits a tree
	Given a ski slope map
	When parsed
	Given a ski slope of 1
	When skiing
	Then the tree hit is counted
@Collision
Scenario: Skier hits a tree with a non-symetric location
	Given a ski slope map
	When parsed
	Given a ski slope of 1
	When skiing
	Then the tree hit is counted
@Collision
Scenario: Skier does not hit a tree
	Given a ski slope map
	When parsed
	Given a ski slope of 2
	When skiing
	Then the tree hit is not counted

@SlopeTests
Scenario: Slope of 1 hit count
	Given a ski slope map
	When parsed
	Given a ski slope of 1
	When skiing the whole slope
	Then the skier hits 3 trees

Scenario: Slope of 2 hit count
	Given a ski slope map
	When parsed
	Given a ski slope of 2
	When skiing the whole slope
	Then the skier hits 1 trees

Scenario: Best slope of all
	Given a ski slope map
	When parsed
	And skiing all slope angles
	Then the best slope is 0


