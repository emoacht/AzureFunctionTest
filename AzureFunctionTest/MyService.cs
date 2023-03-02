using System;

namespace AzureFunctionTest;

public interface IMyService
{
	string GetMessage();
}

public class MyService : IMyService
{
	private readonly Guid _id;

	public MyService()
	{
		_id = Guid.NewGuid();
	}

	public string GetMessage() => $"Hello {_id}";
}
