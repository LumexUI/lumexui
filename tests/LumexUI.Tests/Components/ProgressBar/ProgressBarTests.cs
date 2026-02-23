// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Tests.Extensions;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class ProgressBarTests : TestContext
{
	public ProgressBarTests()
	{
		Services.AddSingleton<TwMerge>();
	}

	[Fact]
	public void ProgressBar_ShouldRenderCorrectly()
	{
		var action = () => RenderComponent<LumexProgressBar>();

		action.Should().NotThrow();
	}

	[Fact]
	public void ProgressBar_ShouldHaveTrackSlot()
	{
		var cut = RenderComponent<LumexProgressBar>();

		cut.FindBySlot( "track" ).Should().NotBeNull();
	}

	[Fact]
	public void ProgressBar_ShouldHaveFillSlot()
	{
		var cut = RenderComponent<LumexProgressBar>();

		cut.FindBySlot( "fill" ).Should().NotBeNull();
	}

	[Fact]
	public void ProgressBar_WithValue_ShouldSetCorrectFillWidth()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.MaxValue, 100 )
		);

		var fill = cut.FindBySlot( "fill" );
		var style = fill.GetAttribute( "style" );

		style.Should().Contain( "width: 50.00%" );
	}

	[Fact]
	public void ProgressBar_WithCustomMaxValue_ShouldCalculateCorrectPercentage()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Value, 75 )
			.Add( p => p.MaxValue, 150 )
		);

		var fill = cut.FindBySlot( "fill" );
		var style = fill.GetAttribute( "style" );

		style.Should().Contain( "width: 50.00%" );
	}

	[Fact]
	public void ProgressBar_WithValueAboveMaxValue_ShouldClampToMaxValue()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Value, 150 )
			.Add( p => p.MaxValue, 100 )
		);

		var fill = cut.FindBySlot( "fill" );
		var style = fill.GetAttribute( "style" );

		style.Should().Contain( "width: 100.00%" );
	}

	[Fact]
	public void ProgressBar_WithNegativeValue_ShouldClampToZero()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Value, -10 )
			.Add( p => p.MaxValue, 100 )
		);

		var fill = cut.FindBySlot( "fill" );
		var style = fill.GetAttribute( "style" );

		style.Should().Contain( "width: 0.00%" );
	}

	[Fact]
	public void ProgressBar_IsLoadingBar_ShouldSetFillWidthTo100Percent()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.IsLoadingBar, true )
			.Add( p => p.Value, 50 )
		);

		var fill = cut.FindBySlot( "fill" );
		var style = fill.GetAttribute( "style" );

		style.Should().Contain( "width: 100%" );
	}

	[Fact]
	public void ProgressBar_IsLoadingBar_ShouldHaveShimmerAnimation()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.IsLoadingBar, true )
		);

		var shimmer = cut.Find( ".animate-shimmer" );
		shimmer.Should().NotBeNull();
	}

	[Fact]
	public void ProgressBar_IsLoadingBar_FillShouldHaveAnimateProgressLoading()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.IsLoadingBar, true )
		);

		var fill = cut.FindBySlot( "fill" );

		fill.ClassList.Should().Contain( "animate-progress-loading" );
	}

	[Fact]
	public void ProgressBar_ShowLabel_ShouldRenderLabel()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.Value, 50 )
		);

		cut.FindBySlot( "label" ).Should().NotBeNull();
	}

	[Fact]
	public void ProgressBar_ShowLabelFalse_ShouldNotRenderLabel()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, false )
			.Add( p => p.Value, 50 )
		);

		cut.FindBySlot( "label" ).Should().BeNull();
	}

	[Fact]
	public void ProgressBar_IsLoadingBar_ShouldNotShowLabel()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.IsLoadingBar, true )
			.Add( p => p.ShowLabel, true )
		);

		cut.FindBySlot( "label" ).Should().BeNull();
	}

	[Fact]
	public void ProgressBar_ShowLabel_ShouldDisplayDefaultPercentage()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.Value, 75 )
		);

		var label = cut.FindBySlot( "label" );
		label.TextContent.Should().Contain( "75%" );
	}

	[Fact]
	public void ProgressBar_IsLabelInline_ShouldRenderLabelInsideTrack()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.IsLabelInline, true )
			.Add( p => p.Value, 50 )
		);

		var track = cut.FindBySlot( "track" );
		var label = cut.FindBySlot( "label" );

		track.Should().NotBeNull();
		label.Should().NotBeNull();

		track!.Children.Any( c => c.OuterHtml == label.OuterHtml).Should().BeTrue();
	}

	[Fact]
	public void ProgressBar_IsLabelInlineFalse_ShouldRenderLabelOutsideTrack()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.IsLabelInline, false )
			.Add( p => p.Value, 50 )
		);

		var track = cut.FindBySlot( "track" );
		var label = cut.FindBySlot( "label" );

		track.Should().NotBeNull();
		label.Should().NotBeNull();

		track!.Children.Any( c => c.OuterHtml == label.OuterHtml ).Should().BeFalse();
	}

	[Theory]
	[InlineData( Align.Start )]
	[InlineData( Align.Center )]
	[InlineData( Align.End )]
	public void ProgressBar_LabelPosition_ShouldApplyCorrectPosition( Align position )
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.IsLabelInline, true )
			.Add( p => p.LabelPosition, position )
			.Add( p => p.Value, 50 )
		);

		var label = cut.FindBySlot( "label" );
		label.Should().NotBeNull();
	}

	[Fact]
	public void ProgressBar_LabelContent_ShouldRenderCustomContent()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.Value, 70 )
			.Add( p => p.LabelContent, context => $"Custom: {context.Percentage:F0}%" )
		);

		var label = cut.FindBySlot( "label" );
		label.TextContent.Should().Contain( "Custom: 70%" );
	}

	[Fact]
	public void ProgressBar_LabelContent_ShouldHaveAccessToContext()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.Value, 60 )
			.Add( p => p.MaxValue, 200 )
			.Add( p => p.LabelContent, context =>
			{
				context.Percentage.Should().Be( 30.0 );
				context.ClampedValue.Should().Be( 60.0 );
				context.Value.Should().Be( 60.0 );
				context.MaxValue.Should().Be( 200.0 );
				return "Test";
			} )
		);

		var label = cut.FindBySlot( "label" );
		label.Should().NotBeNull();
	}

	[Theory]
	[InlineData( ThemeColor.Default )]
	[InlineData( ThemeColor.Primary )]
	[InlineData( ThemeColor.Secondary )]
	[InlineData( ThemeColor.Success )]
	[InlineData( ThemeColor.Warning )]
	[InlineData( ThemeColor.Danger )]
	[InlineData( ThemeColor.Info )]
	public void ProgressBar_Color_ShouldApplyCorrectColor( ThemeColor color )
	{
		var action = () => RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Color, color )
		);

		action.Should().NotThrow();
	}

	[Theory]
	[InlineData( Size.Small )]
	[InlineData( Size.Medium )]
	[InlineData( Size.Large )]
	public void ProgressBar_Size_ShouldApplyCorrectSize( Size size )
	{
		var action = () => RenderComponent<LumexProgressBar>( p => p
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
	public void ProgressBar_Radius_ShouldApplyCorrectRadius( Radius radius )
	{
		var action = () => RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Radius, radius )
		);

		action.Should().NotThrow();
	}

	[Fact]
	public void ProgressBar_ShouldHaveCorrectAriaAttributes()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.MaxValue, 100 )
		);

		var track = cut.FindBySlot( "track" );
		track.GetAttribute( "role" ).Should().Be( "progressbar" );
		track.GetAttribute( "aria-valuenow" ).Should().Be( "50" );
		track.GetAttribute( "aria-valuemin" ).Should().Be( "0" );
		track.GetAttribute( "aria-valuemax" ).Should().Be( "100" );
	}

	[Fact]
	public void ProgressBar_IsLoadingBar_ShouldHaveNullAriaValuenow()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.IsLoadingBar, true )
		);

		var track = cut.FindBySlot( "track" );
		track.HasAttribute( "aria-valuenow" ).Should().BeFalse();
		track.GetAttribute( "aria-label" ).Should().Be( "Loading" );
	}

	[Fact]
	public void ProgressBar_WithZeroMaxValue_ShouldHandleGracefully()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Value, 50 )
			.Add( p => p.MaxValue, 0 )
		);

		var fill = cut.FindBySlot( "fill" );
		var style = fill.GetAttribute( "style" );

		style.Should().Contain( "width: 0.00%" );
	}

	[Fact]
	public void ProgressBar_WithCustomClasses_ShouldApplyClasses()
	{
		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.Class, "custom-class" )
		);

		var track = cut.FindBySlot( "track" );
		track.ClassList.Should().Contain( "custom-class" );
	}

	[Fact]
	public void ProgressBar_WithCustomSlots_ShouldApplySlotClasses()
	{
		var slots = new ProgressBarSlots
		{
			Track = "custom-track",
			Fill = "custom-fill",
			Label = "custom-label"
		};

		var cut = RenderComponent<LumexProgressBar>( p => p
			.Add( p => p.ShowLabel, true )
			.Add( p => p.Value, 50 )
			.Add( p => p.Classes, slots )
		);

		var track = cut.FindBySlot( "track" );
		var fill = cut.FindBySlot( "fill" );
		var label = cut.FindBySlot( "label" );

		track.ClassList.Should().Contain( "custom-track" );
		fill.ClassList.Should().Contain( "custom-fill" );
		label.ClassList.Should().Contain( "custom-label" );
	}
}
