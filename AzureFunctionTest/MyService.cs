
namespace AzureFunctionTest;

public interface IMyService
{
	string GetMessage();
}

public class MyService : IMyService
{
	public string GetMessage() => "Message";
}
