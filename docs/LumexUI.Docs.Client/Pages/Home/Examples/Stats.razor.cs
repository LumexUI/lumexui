// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class Stats : ExampleComponentBase
{
	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	private readonly Dictionary<ThemeColor, string> _chartCssVariables = new()
	{
		[ThemeColor.Default] = "[--chart:var(--lumex-default-900)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
		[ThemeColor.Primary] = "[--chart:var(--lumex-primary)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
		[ThemeColor.Secondary] = "[--chart:var(--lumex-secondary)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
		[ThemeColor.Success] = "[--chart:var(--lumex-success)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
		[ThemeColor.Warning] = "[--chart:var(--lumex-warning)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
		[ThemeColor.Danger] = "[--chart:var(--lumex-danger)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
		[ThemeColor.Info] = "[--chart:var(--lumex-info)] [--chart-fill:--alpha(var(--chart)_/_5%)]",
	};

	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			await JSRuntime.InvokeVoidAsync( "charts.stats.initialize" );
		}
	}
}