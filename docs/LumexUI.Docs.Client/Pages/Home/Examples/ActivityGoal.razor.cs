// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class ActivityGoal : ExampleComponentBase
{
	private const int _minCalories = 200;
	private const int _maxCalories = 400;

	private readonly Dictionary<ThemeColor, string> _chartCssVariables = new()
	{
		[ThemeColor.Default] = "[--chart:var(--lumex-default-900)]",
		[ThemeColor.Primary] = "[--chart:var(--lumex-primary)]",
		[ThemeColor.Secondary] = "[--chart:var(--lumex-secondary)]",
		[ThemeColor.Success] = "[--chart:var(--lumex-success)]",
		[ThemeColor.Warning] = "[--chart:var(--lumex-warning)]",
		[ThemeColor.Danger] = "[--chart:var(--lumex-danger)]",
		[ThemeColor.Info] = "[--chart:var(--lumex-info)]",
	};

	private int _caloriesDay = 350;

	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			await JSRuntime.InvokeVoidAsync( "charts.activity.initialize" );
		}
	}

	private void DecrementCalories() => SetCalories( -10 );
	private void IncrementCalories() => SetCalories( +10 );
	private void SetCalories( int value ) => _caloriesDay += value;
}
