using System;
using TechTalk.SpecFlow;
using Skiing_Library;

namespace Skiing_Tests.StepDefinitions
{
    [Binding]
    public class SkiingStepDefinitions
    {
        private ScenarioContext context;

        public SkiingStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"a tree input file")]
        public void GivenATreeInputFile()
        {
            string[] lines = TreeParser.ReadFile(Environment.CurrentDirectory + "../../../TreeMap.txt");
            context.Add("fileLines", lines);
        }

        [When(@"parsed")]
        public void WhenParsed()
        {
            var skiSlope = new SkiSlope(TreeParser.Parse(context.Get<string[]>("fileLines")));
            
            context.Add("skiSlope", skiSlope);
        }

        [Then(@"the file is parsed correctly")]
        public void ThenTheFileIsParsedCorrectly()
        {
            int treeCount = 19;
            context.Get<SkiSlope>("skiSlope").CountTrees().Should().Be(treeCount);
        }

        [Given(@"a tree input line of (.*) in length")]
        public void GivenATreeInputLineOfInLength(int lineLength)
        {
            context.Add("lineLength", lineLength);
        }

        [When(@"skier moves to (.*),(.*)")]
        public void WhenSkierMovesTo(int xPos, int yPos)
        {
            var skier = new Skier(xPos - 1,yPos - 1);
            skier.Move();
            context.Add("skier", skier);
        }

        [Then(@"the skiers next location is (.*),(.*)")]
        public void ThenTheSkiersNextLocationIs(int xPos, int yPos)
        {
            var skier = context.Get<Skier>("skier");
            skier.XPosition.Should().Be(xPos);
            skier.YPosition.Should().Be(yPos);
        }

        [Given(@"a starting location of (.*),(.*)")]
        public void GivenAStartingLocationOf(int xPos, int yPos)
        {
            var skier = new Skier(xPos,yPos);
            context.Add("skier",skier);
        }

        [When(@"skiing a slope of (.*)")]
        public void WhenSkiingASlopeOf(int slope)
        {
            context.Get<Skier>("skier").SetSlope(slope);
        }


        [Given(@"a tree location of (.*),(.*)")]
        public void GivenATreeLocationOf(int xPos, int yPos)
        {
            context.Add("treePosition", (xPos, yPos));
        }

        [Then(@"the tree hit is counted")]
        public void ThenTheTreeHitIsCounted()
        {
            var skiSlope = new SkiSlope(new bool[,] { { false, false }, { false, true } });
            var skier = context.Get<Skier>("skier");
            var xPos = skier.GetXPosition();
            var yPos = skier.GetYPosition();
            skiSlope.CheckCollision(xPos,yPos).Should().BeTrue();
        }
    }
}