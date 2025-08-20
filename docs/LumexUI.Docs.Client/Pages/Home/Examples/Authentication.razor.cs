using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class Authentication : ExampleComponentBase
{
	[SupplyParameterFromForm]
	private Login LoginModel { get; set; } = new();

	private bool _isEmailLogin;

	private void Submit() { }

	public sealed record Login
	{
		public string? Email { get; set; }
	}
}