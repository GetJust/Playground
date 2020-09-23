using Just.Test.Functions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Just.Test.Functions.Tests
{
	public class MathFunctionsTests
	{
		[Fact]
		public async Task AdditionTest()
		{
			var subject = new MathFunctions(new MathService());

			var log = new Mock<ILogger>(MockBehavior.Default);

			var response = await subject.Add(new HttpRequestMessage(), 2, 2, log.Object);
			var actual = response as OkObjectResult;

			Assert.NotNull(actual);
			Assert.Equal(200, actual.StatusCode);
			Assert.Equal(4, actual.Value);
		}

		[Fact]
		public async Task SubtractionTest()
		{
			var subject = new MathFunctions(new MathService());

			var log = new Mock<ILogger>(MockBehavior.Default);

			var response = await subject.Subtract(new HttpRequestMessage(), 4, 3, log.Object);
			var actual = response as OkObjectResult;

			Assert.NotNull(actual);
			Assert.Equal(200, actual.StatusCode);
			Assert.Equal(1, actual.Value);
		}
	}
}
