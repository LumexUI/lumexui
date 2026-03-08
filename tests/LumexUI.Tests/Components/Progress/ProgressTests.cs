// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Tests.Extensions;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class ProgressTests : TestContext
{
	public ProgressTests()
	{
		Services.AddSingleton<TwMerge>();
	}

	[Fact]
	public void Progress_ShouldRenderCorrectly()
	{
		var action = () => RenderComponent<LumexProgress>();

		action.Should().NotThrow();
	}

	[Fact]
	public void Progress_ShouldHaveTrackSlot()
	{
		var cut = RenderComponent<LumexProgress>();

		cut.FindBySlot( "track" ).Should().NotBeNull();
	}

	[Fact]
	public void Progress_ShouldHaveIndicatorSlot()
	{
		var cut = RenderComponent<LumexProgress>();

		cut.FindBySlot( "indicator" ).Should().NotBeNull();
	}

	[Fact]
	public void Progress_WithValue_ShouldSetCorrectIndicatorWidth()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.MaxValue, 100 )
		);

		var indicator = cut.FindBySlot( "indicator" );
		var style = indicator.GetAttribute( "style" );

		style.Should().Contain( "width: 50.00%" );
	}

	[Fact]
	public void Progress_WithCustomMinAndMaxValue_ShouldCalculateCorrectPercentage()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 75 )
			.Add( p => p.MinValue, 50 )
			.Add( p => p.MaxValue, 150 )
		);

		var indicator = cut.FindBySlot( "indicator" );
		var style = indicator.GetAttribute( "style" );

		style.Should().Contain( "width: 25.00%" );
	}

	[Fact]
	public void Progress_WithValueAboveMaxValue_ShouldClampToMaxValue()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 150 )
			.Add( p => p.MaxValue, 100 )
		);

		var indicator = cut.FindBySlot( "indicator" );
		var style = indicator.GetAttribute( "style" );

		style.Should().Contain( "width: 100.00%" );
	}

	[Fact]
	public void Progress_WithValueBelowMinValue_ShouldClampToMinValue()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, -10 )
			.Add( p => p.MinValue, 0 )
			.Add( p => p.MaxValue, 100 )
		);

		var indicator = cut.FindBySlot( "indicator" );
		var style = indicator.GetAttribute( "style" );

		style.Should().Contain( "width: 0.00%" );
	}

	[Fact]
	public void Progress_Indeterminate_ShouldSetIndicatorWidthTo100Percent()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Indeterminate, true )
			.Add( p => p.Value, 50 )
		);

		var indicator = cut.FindBySlot( "indicator" );
		var style = indicator.GetAttribute( "style" );

		style.Should().Contain( "width: 100%" );
	}

	[Fact]
	public void Progress_Indeterminate_ShouldHaveAnimateProgressLoading()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Indeterminate, true )
		);

		var indicator = cut.FindBySlot( "indicator" );

		indicator.ClassList.Should().Contain( "animate-progress-loading" );
	}

	[Fact]
	public void Progress_ShowValueLabel_ShouldRenderValueLabel()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.ShowValueLabel, true )
			.Add( p => p.Value, 50 )
		);

		cut.FindBySlot( "value" ).Should().NotBeNull();
	}

	[Fact]
	public void Progress_ShowValueLabelFalse_ShouldNotRenderValueLabel()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.ShowValueLabel, false )
			.Add( p => p.Value, 50 )
		);

		cut.FindBySlot( "value" ).Should().BeNull();
	}

	[Fact]
	public void Progress_Indeterminate_ShouldNotShowValueLabel()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Indeterminate, true )
			.Add( p => p.ShowValueLabel, true )
		);

		cut.FindBySlot( "value" ).Should().BeNull();
	}

	[Fact]
	public void Progress_WithLabel_ShouldRenderLabel()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Label, "Downloading..." )
			.Add( p => p.Value, 50 )
		);

		cut.FindBySlot( "label" ).Should().NotBeNull();
		cut.FindBySlot( "label" ).TextContent.Should().Contain( "Downloading..." );
	}

	[Fact]
	public void Progress_WithoutLabel_ShouldNotRenderLabel()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 50 )
		);

		cut.FindBySlot( "label" ).Should().BeNull();
	}

	[Fact]
	public void Progress_DefaultShowValueLabel_ShouldNotDisplayValueLabelByDefault()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 75 )
		);

		var value = cut.FindBySlot( "value" );
		value.Should().BeNull();
	}

	[Fact]
	public void Progress_WithCustomValueLabel_ShouldDisplayCustomValue()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.ShowValueLabel, true )
			.Add( p => p.ValueLabel, "50/100" )
		);

		var value = cut.FindBySlot( "value" );
		value.TextContent.Should().Contain( "50/100" );
	}

	[Theory]
	[InlineData( ThemeColor.Default )]
	[InlineData( ThemeColor.Primary )]
	[InlineData( ThemeColor.Secondary )]
	[InlineData( ThemeColor.Success )]
	[InlineData( ThemeColor.Warning )]
	[InlineData( ThemeColor.Danger )]
	[InlineData( ThemeColor.Info )]
	public void Progress_Color_ShouldApplyCorrectColor( ThemeColor color )
	{
		var action = () => RenderComponent<LumexProgress>( p => p
			.Add( p => p.Color, color )
		);

		action.Should().NotThrow();
	}

	[Theory]
	[InlineData( Size.Small )]
	[InlineData( Size.Medium )]
	[InlineData( Size.Large )]
	public void Progress_Size_ShouldApplyCorrectSize( Size size )
	{
		var action = () => RenderComponent<LumexProgress>( p => p
			.Add( p => p.Size, size )
		);

		action.Should().NotThrow();
	}

	[Theory]
	[InlineData( Radius.None )]
	[InlineData( Radius.Small )]
	[InlineData( Radius.Medium )]
	[InlineData( Radius.Large )]
	[InlineData( Radius.Full )]
	public void Progress_Radius_ShouldApplyCorrectRadius( Radius radius )
	{
		var action = () => RenderComponent<LumexProgress>( p => p
			.Add( p => p.Radius, radius )
		);

		action.Should().NotThrow();
	}

	[Fact]
	public void Progress_ShouldHaveCorrectAriaAttributes()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.MaxValue, 100 )
		);

		var base_ = cut.FindBySlot( "base" );
		base_.GetAttribute( "role" ).Should().Be( "progressbar" );
		base_.GetAttribute( "aria-valuenow" ).Should().Be( "50" );
		base_.GetAttribute( "aria-valuemin" ).Should().Be( "0" );
		base_.GetAttribute( "aria-valuemax" ).Should().Be( "100" );
	}

	[Fact]
	public void Progress_Indeterminate_ShouldHaveNullAriaValuenow()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Indeterminate, true )
		);

		var base_ = cut.FindBySlot( "base" );
		base_.HasAttribute( "aria-valuenow" ).Should().BeFalse();
		base_.GetAttribute( "aria-label" ).Should().Be( "Loading" );
	}

	[Fact]
	public void Progress_WithZeroMaxValue_ShouldHandleGracefully()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.MaxValue, 0 )
		);

		var indicator = cut.FindBySlot( "indicator" );
		var style = indicator.GetAttribute( "style" );

		style.Should().Contain( "width: 0.00%" );
	}

	[Fact]
	public void Progress_WithCustomClasses_ShouldApplyClasses()
	{
		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Class, "custom-class" )
		);

		var base_ = cut.FindBySlot( "base" );
		base_.ClassList.Should().Contain( "custom-class" );
	}

	[Fact]
	public void Progress_WithCustomSlots_ShouldApplySlotClasses()
	{
		var slots = new ProgressSlots
		{
			Track = "custom-track",
			Indicator = "custom-indicator",
			Label = "custom-label"
		};

		var cut = RenderComponent<LumexProgress>( p => p
			.Add( p => p.Label, "Testing..." )
			.Add( p => p.Value, 50 )
			.Add( p => p.Classes, slots )
		);

		var track = cut.FindBySlot( "track" );
		var indicator = cut.FindBySlot( "indicator" );
		var label = cut.FindBySlot( "label" );

		track.ClassList.Should().Contain( "custom-track" );
		indicator.ClassList.Should().Contain( "custom-indicator" );
		label.ClassList.Should().Contain( "custom-label" );
	}
}
