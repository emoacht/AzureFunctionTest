using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionTest.Startup))]

namespace AzureFunctionTest;

public class Startup : FunctionsStartup
{
	public override void Configure(IFunctionsHostBuilder builder)
	{
		builder.Services.AddHttpClient();

		builder.Services.AddScoped<IMyService, MyService>();
	}
}
