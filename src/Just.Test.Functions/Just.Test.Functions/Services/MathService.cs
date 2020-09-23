namespace Just.Test.Functions.Services
{
	public class MathService : IMathService
	{
		public int Add(int addend1, int addend2)
		{
			return addend1 + addend2;
		}

		public int Subtract(int minuend, int subtrahend)
		{
			return minuend - subtrahend;
		}
	}
}
