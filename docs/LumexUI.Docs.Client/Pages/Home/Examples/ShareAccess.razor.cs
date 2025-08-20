// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class ShareAccess
{
	private readonly List<Person> _peopleWithAccess =
	[
		new Person("Pepper Potts", "pepper.potts@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/female/4.png"),
		new Person("Peter Parker", "peter.parker@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/male/5.png"),
		new Person("Hope van Dyne", "hope.van.dyne@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/female/5.png"),
		new Person("Stephen Strange", "stephen.strange@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/male/6.png")
	];

	private readonly RenderFragment _renderPeopleWithAccess;

	private bool _isCopied;

	public ShareAccess()
	{
		_renderPeopleWithAccess = RenderPeopleWithAccess;
	}

	private async Task HandleCopyAsync()
	{
		_isCopied = true;

		await Task.Delay( 2000 );

		_isCopied = false;
	}

	private record Person( string Name, string Email, string Avatar );
}