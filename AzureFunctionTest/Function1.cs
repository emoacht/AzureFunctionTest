using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionTest;

public class Function1
{
	private readonly HttpClient _client;
	private readonly IMyService _service;

	public Function1(IHttpClientFactory httpClientFactory, IMyService service)
	{
		_client = httpClientFactory.CreateClient();
		_service = service;
	}

	[FunctionName("Function1")]
	public async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
		ILogger log)
	{
		var response = await _client.GetAsync("https://www.microsoft.com");
		var message = $"{_service.GetMessage()}: {response.Headers.Date}";

		return new OkObjectResult(message);
	}
}
