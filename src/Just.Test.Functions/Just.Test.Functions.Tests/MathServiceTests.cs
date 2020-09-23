using Just.Test.Functions.Services;
using Xunit;

namespace Just.Test.Functions.Tests
{
	public class MathServiceTests
	{
		[Fact]
		public void AdditionTest()
		{
			var subject = new MathService();

			Assert.Equal(4, subject.Add(2, 2));
		}

		[Fact]
		public void SubtractionTest()
		{
			var subject = new MathService();

			Assert.Equal(1, subject.Subtract(4, 3));
		}
	}
}
