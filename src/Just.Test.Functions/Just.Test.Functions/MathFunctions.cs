using Just.Test.Functions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Just.Test.Functions
{
	public class MathFunctions
    {
		private readonly IMathService mathService;

		public MathFunctions(IMathService mathService)
		{
			this.mathService = mathService;
		}

        [FunctionName(nameof(Add))]
        public async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "add/{addend1}/{addend2}")] HttpRequest req,
			int addend1,
			int addend2,
			ILogger log)
        {
			return new OkObjectResult(mathService.Add(addend1, addend2));
        }

		[FunctionName(nameof(Subtract))]
		public async Task<IActionResult> Subtract(
			[HttpTrigger(AuthorizationLevel.Function, "post", Route = "subtract/{minuend}/{subtrahend}")] HttpRequest req,
			int minuend,
			int subtrahend,
			ILogger log)
		{
			return new OkObjectResult(mathService.Subtract(minuend, subtrahend));
		}
	}
}
