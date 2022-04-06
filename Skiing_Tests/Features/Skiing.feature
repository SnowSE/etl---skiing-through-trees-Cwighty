﻿Feature: Skiing

A short summary of the feature

@ReadMap
Scenario: Read Tree Map
	Given a tree input file
	When parsed
	Then the file is parsed correctly

@LoopMap
Scenario: Loop tree map
	Given a tree input line of 31 in length
	Given a starting location of 0,0
	When skiing a slope of 32
	Then the skiers next location is 0,1

@Correct
Scenario: Skier Moves correctly
	Given a starting location of 0,0
	When skiing a slope of 1
	Then the skiers next location is 1,1

@MoreCorrect
Scenario: Skier Moves Differently Correctly 
	Given a starting location of 0,0
	When skiing a slope of 2
	Then the skiers next location is 2,1

@Collision
Scenario: Skier hits a tree
	Given a starting location of 0,0
	Given a tree location of 1,1
	When skiing a slope of 1
	Then the tree hit is counted

