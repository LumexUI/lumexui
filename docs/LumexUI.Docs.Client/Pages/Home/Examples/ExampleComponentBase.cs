// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Docs.Client.Services;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public abstract class ExampleComponentBase : ComponentBase, IDisposable
{
	[Inject] private DocsThemeService ThemeService { get; set; } = default!;

	protected ThemeColor ThemeColor => ThemeService.GetThemeColor();

	protected override void OnInitialized()
	{
		ThemeService.OnChanged += StateHasChanged;
	}

	void IDisposable.Dispose()
	{
		ThemeService.OnChanged -= StateHasChanged;
	}
}
