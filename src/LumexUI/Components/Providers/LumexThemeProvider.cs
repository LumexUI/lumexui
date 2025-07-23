// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Services;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that provides theming support.
/// </summary>
[ExcludeFromCodeCoverage]
public class LumexThemeProvider : ComponentBase
{
	[Inject] private ThemeService ThemeService { get; set; } = default!;

	/// <inheritdoc />	
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			await ThemeService.InitializeAsync();
		}
	}
}
