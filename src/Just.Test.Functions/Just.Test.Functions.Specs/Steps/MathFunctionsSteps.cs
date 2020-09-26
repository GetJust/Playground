using Just.Test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Just.Test.Functions.Specs.Steps
{
	[Binding]
	public class MathFunctionsSteps
	{
		private readonly IMathService mathService;
		private readonly MathFunctions mathFunctions;

		private int num1;
		private int num2;
		private int? actualStatusCode;
		private int actualValue;

		private readonly Mock<ILogger> log = new Mock<ILogger>(MockBehavior.Default);

		public MathFunctionsSteps()
		{
			this.mathService = new MathService();
			this.mathFunctions = new MathFunctions(this.mathService);
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

		[When(@"an API call is made to add the two numbers")]
		public async Task WhenAnAPICallIsMadeToAddTheTwoNumbers()
		{
			var response = await mathFunctions.Add(new HttpRequestMessage(), num1, num2, log.Object);
			var actual = response as OkObjectResult;

			actualStatusCode = actual.StatusCode;
			actualValue = (int)actual.Value;
		}

		[When(@"an API call is made to subtract the two numbers")]
		public async Task WhenAnAPICallIsMadeToSubtractTheTwoNumbers()
		{
			var response = await mathFunctions.Subtract(new HttpRequestMessage(), num1, num2, log.Object);
			var actual = response as OkObjectResult;

			actualStatusCode = actual.StatusCode;
			actualValue = (int)actual.Value;
		}

		[Then(@"the API should return an HTTP OK status code")]
		public void ThenTheAPIShouldReturnAnHTTPOKStatusCode()
		{
			Assert.Equal(200, actualStatusCode);
		}

		[Then(@"the result should be (.*)")]
		public void ThenTheResultShouldBe(int expected)
		{
			Assert.Equal(expected, actualValue);
		}

	}
}
