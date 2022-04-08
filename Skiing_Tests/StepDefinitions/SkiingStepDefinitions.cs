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

        [Given(@"a ski slope map")]
        public void GivenATreeInputFile()
        {
            string path = Environment.CurrentDirectory + "/../../../TreeMap.txt";
            context.Add("filePath", path);
        }

        [When(@"parsed")]
        public void WhenParsed()
        {
            var skiSlope = new SkiSlope(context.Get<string>("filePath"));
            
            context.Add("skiSlope", skiSlope);
        }

        [Then(@"the file is parsed correctly")]
        public void ThenTheFileIsParsedCorrectly()
        {
            int treeCount = 9;
            context.Get<SkiSlope>("skiSlope").CountAllTrees().Should().Be(treeCount);
        }

        [Then(@"the skiers next location is (.*),(.*)")]
        public void ThenTheSkiersNextLocationIs(int xPos, int yPos)
        {
            var skier = context.Get<Skier>("skier");
            skier.XPosition.Should().Be(xPos);
            skier.YPosition.Should().Be(yPos);
        }

        [Given(@"a ski slope of (.*)")]
        public void GivenASkiSlopeOf(int slope)
        {
            var skier = new Skier(slope, context.Get<SkiSlope>("skiSlope").Width);
            context.Add("skier", skier);
        }

        [When(@"skiing")]
        public void WhenSkiingASlopeOf()
        {
            context.Get<Skier>("skier").Move();
        }

        [When(@"skiing the whole slope")]
        public void WhenSkiingTheWholeSlope()
        {
            var treeHitCount = context.Get<SkiSlope>("skiSlope").CountTreesHitForSlope(context.Get<Skier>("skier").GetSlope());
            context.Add("treesHit", treeHitCount);
        }

        [When(@"skiing all slope angles")]
        public void WhenSkiingAllSlopeAngles()
        {
            var bestSlope = context.Get<SkiSlope>("skiSlope").CalculateBestSlope();
            context.Add("bestSlope", bestSlope);
        }



        [Then(@"the tree hit is counted")]
        public void ThenTheTreeHitIsCounted()
        {
            var skiSlope = context.Get<SkiSlope>("skiSlope");
            var skier = context.Get<Skier>("skier");
            var xPos = skier.GetXPosition();
            var yPos = skier.GetYPosition();
            skiSlope.CheckCollision(xPos,yPos).Should().BeTrue();
        }

        [Then(@"the tree hit is not counted")]
        public void ThenTheTreeHitIsNotCounted()
        {
            var skiSlope = context.Get<SkiSlope>("skiSlope");
            var skier = context.Get<Skier>("skier");
            var xPos = skier.GetXPosition();
            var yPos = skier.GetYPosition();
            skiSlope.CheckCollision(xPos, yPos).Should().BeFalse();
        }

        [Then(@"the skier hits (.*) trees")]
        public void ThenTheSkierHitsTrees(int totalTreesHit)
        {
            context.Get<int>("treesHit").Should().Be(totalTreesHit);
        }

        [Then(@"the best slope is (.*)")]
        public void ThenTheBestSlopeIs(int bestSlope)
        {
            context.Get<int>("bestSlope").Should().Be(bestSlope);
        }
    }
}
