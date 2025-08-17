// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class Usage : ExampleComponentBase
{
	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	private readonly Dictionary<ThemeColor, string> _chartCssVariables = new()
	{
		[ThemeColor.Default] = "[--chart-1:var(--color-zinc-900)] [--chart-2:var(--color-zinc-700)] [--chart-3:var(--color-zinc-500)] [--chart-4:var(--color-zinc-300)]",
		[ThemeColor.Primary] = "[--chart-1:var(--color-blue-900)] [--chart-2:var(--color-blue-600)] [--chart-3:var(--color-blue-400)] [--chart-4:var(--color-blue-300)]",
		[ThemeColor.Secondary] = "[--chart-1:var(--color-violet-900)] [--chart-2:var(--color-violet-600)] [--chart-3:var(--color-violet-400)] [--chart-4:var(--color-violet-300)]",
		[ThemeColor.Success] = "[--chart-1:var(--color-green-900)] [--chart-2:var(--color-green-600)] [--chart-3:var(--color-green-400)] [--chart-4:var(--color-green-300)]",
		[ThemeColor.Warning] = "[--chart-1:var(--color-amber-900)] [--chart-2:var(--color-amber-600)] [--chart-3:var(--color-amber-400)] [--chart-4:var(--color-amber-300)]",
		[ThemeColor.Danger] = "[--chart-1:var(--color-rose-900)] [--chart-2:var(--color-rose-600)] [--chart-3:var(--color-rose-400)] [--chart-4:var(--color-rose-300)]",
		[ThemeColor.Info] = "[--chart-1:var(--color-sky-900)] [--chart-2:var(--color-sky-600)] [--chart-3:var(--color-sky-400)] [--chart-4:var(--color-sky-300)]",
	};

	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			await JSRuntime.InvokeVoidAsync( "charts.usage.initialize" );
		}
	}
}