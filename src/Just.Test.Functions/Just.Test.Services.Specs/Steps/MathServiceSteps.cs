using Just.Test.Services;
using TechTalk.SpecFlow;
using Xunit;

namespace Just.Test.Functions.Specs.Steps
{
	[Binding]
    public class MathServiceSteps
    {
		private readonly IMathService mathService;

		private int num1;
		private int num2;
		private int actualValue;


		public MathServiceSteps()
		{
			this.mathService = new MathService();
		}

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num1)
        {
			this.num1 = num1;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int num2)
        {
			this.num2 = num2;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
			actualValue = mathService.Add(num1, num2);
        }

		[When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
			actualValue = mathService.Subtract(num1, num2);
        }

		[Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
			Assert.Equal(expected, actualValue);
        }

	}
}
