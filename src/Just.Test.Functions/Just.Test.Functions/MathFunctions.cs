using Just.Test.Functions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
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
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "add/{addend1}/{addend2}")] HttpRequestMessage req,
			int addend1,
			int addend2,
			ILogger log)
        {
			log.LogInformation($"Executing function: {nameof(Add)}");
			return await Task.FromResult(new OkObjectResult(mathService.Add(addend1, addend2)));
        }

		[FunctionName(nameof(Subtract))]
		public async Task<IActionResult> Subtract(
			[HttpTrigger(AuthorizationLevel.Function, "post", Route = "subtract/{minuend}/{subtrahend}")] HttpRequestMessage req,
			int minuend,
			int subtrahend,
			ILogger log)
		{
			log.LogInformation($"Executing function: {nameof(Add)}");
			return await Task.FromResult(new OkObjectResult(mathService.Subtract(minuend, subtrahend)));
		}
	}
}
