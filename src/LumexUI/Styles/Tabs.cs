// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal class Tabs
{
	private static readonly string _base = ElementClass.Empty()
		.Add( "inline-flex" )
		.ToString();

	private static readonly string _tabList = ElementClass.Empty()
		.Add( "flex" )
		.Add( "h-fit" )
		.Add( "p-1" )
		.Add( "gap-2" )
		.Add( "items-center" )
		.Add( "flex-nowrap" )
		.Add( "overflow-x-scroll" )
		.Add( "scrollbar-hide" )
		.Add( "bg-default-100" )
		.ToString();

	private static readonly string _tab = ElementClass.Empty()
		.Add( "z-0" )
		.Add( "group" )
		.Add( "relative" )
		.Add( "w-full" )
		.Add( "flex" )
		.Add( "px-3" )
		.Add( "py-1" )
		.Add( "justify-center" )
		.Add( "items-center" )
		.Add( "cursor-pointer" )
		.Add( "data-[disabled=true]:!opacity-disabled" )
		.Add( "data-[disabled=true]:cursor-not-allowed" )
		.Add( "data-[selected=false]:hover:opacity-hover" )
		// transition
		.Add( "transition-opacity" )
		// focus ring
		.Add( Utils.FocusVisible )
		.ToString();

	private static readonly string _tabContent = ElementClass.Empty()
		.Add( "z-10" )
		.Add( "relative" )
		.Add( "text-inherit" )
		.Add( "whitespace-nowrap" )
		.Add( "text-default-500" )
		.Add( "group-data-[selected=true]:text-foreground" )
		// transition
		.Add( "transition-colors" )
		.ToString();

	private static readonly string _tabPanel = ElementClass.Empty()
		.Add( "px-1" )
		.Add( "py-3" )
		// focus ring
		.Add( Utils.FocusVisible )
		.ToString();

	private static readonly string _cursor = ElementClass.Empty()
		.Add( "z-0" )
		.Add( "absolute" )
		.Add( "bg-white" )
		.ToString();

	public static TabsSlots GetStyles( LumexTabs tabs, TwMerge twMerge )
	{
		return new TabsSlots()
		{
			Base = twMerge.Merge(
				ElementClass.Empty()
					.Add( _base )
					.Add( GetFullWidthStyles( tabs.FullWidth, slot: nameof( _base ) ) )
					.Add( tabs.Classes?.Base )
					.Add( tabs.Class )
					.ToString() ),

			TabList = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tabList )
					.Add( GetSizeStyles( tabs.Size, slot: nameof( _tabList ) ) )
					.Add( GetRadiusStyles( tabs.Radius, slot: nameof( _tabList ) ) )
					.Add( GetVariantStyles( tabs.Variant, slot: nameof( _tabList ) ) )
					.Add( GetDisabledStyles( tabs.Disabled, slot: nameof( _tabList ) ) )
					.Add( GetFullWidthStyles( tabs.FullWidth, slot: nameof( _tabList ) ) )
					.Add( tabs.Classes?.TabList )
					.ToString() ),

			Tab = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tab )
					.Add( GetSizeStyles( tabs.Size, slot: nameof( _tab ) ) )
					.Add( GetRadiusStyles( tabs.Radius, slot: nameof( _tab ) ) )
					.Add( tabs.Classes?.Tab )
					.ToString() ),

			TabContent = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tabContent )
					.Add( GetCompoundStyles( tabs.Variant, tabs.Color, slot: nameof( _tabContent ) ) )
					.Add( tabs.Classes?.TabContent )
					.ToString() ),

			TabPanel = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tabPanel )
					.Add( tabs.Classes?.TabPanel )
					.ToString() ),

			Cursor = twMerge.Merge(
				ElementClass.Empty()
					.Add( _cursor )
					.Add( GetSizeStyles( tabs.Size, slot: nameof( _cursor ) ) )
					.Add( GetRadiusStyles( tabs.Radius, slot: nameof( _cursor ) ) )
					.Add( GetVariantStyles( tabs.Variant, slot: nameof( _cursor ) ) )
					.Add( GetCompoundStyles( tabs.Variant, tabs.Color, slot: nameof( _cursor ) ) )
					.Add( tabs.Classes?.Cursor )
					.ToString() )
		};
	}

	private static ElementClass GetVariantStyles( TabVariant variant, string slot )
	{
		return variant switch
		{
			TabVariant.Solid => ElementClass.Empty()
				.Add( "inset-0", when: slot is nameof( _cursor ) ),

			TabVariant.Outlined => ElementClass.Empty()
				.Add( "bg-transparent border-2 border-default-200 shadow-xs", when: slot is nameof( _tabList ) )
				.Add( "inset-0", when: slot is nameof( _cursor ) ),

			TabVariant.Underlined => ElementClass.Empty()
				.Add( "bg-transparent", when: slot is nameof( _tabList ) )
				.Add( "h-[2px] w-[80%] bottom-0 shadow-[0_1px_0px_0_rgba(0,0,0,0.05)]", when: slot is nameof( _cursor ) ),

			TabVariant.Light => ElementClass.Empty()
				.Add( "bg-transparent", when: slot is nameof( _tabList ) )
				.Add( "inset-0", when: slot is nameof( _cursor ) ),

			_ => ElementClass.Empty()
		};
	}

	private static ElementClass GetSizeStyles( Size size, string slot )
	{
		return size switch
		{
			Size.Small => ElementClass.Empty()
				.Add( "rounded-medium", when: slot is nameof( _tabList ) )
				.Add( "h-7 text-tiny rounded-small", when: slot is nameof( _tab ) )
				.Add( "rounded-small", when: slot is nameof( _cursor ) ),

			Size.Medium => ElementClass.Empty()
				.Add( "rounded-medium", when: slot is nameof( _tabList ) )
				.Add( "h-8 text-small rounded-small", when: slot is nameof( _tab ) )
				.Add( "rounded-small", when: slot is nameof( _cursor ) ),

			Size.Large => ElementClass.Empty()
				.Add( "rounded-large", when: slot is nameof( _tabList ) )
				.Add( "h-9 text-medium rounded-medium", when: slot is nameof( _tab ) )
				.Add( "rounded-medium", when: slot is nameof( _cursor ) ),

			_ => ElementClass.Empty()
		};
	}

	private static ElementClass GetRadiusStyles( Radius radius, string slot )
	{
		return radius switch
		{
			Radius.None => ElementClass.Empty()
				.Add( "rounded-none", when: slot is nameof( _tabList ) )
				.Add( "rounded-none", when: slot is nameof( _tab ) )
				.Add( "rounded-none", when: slot is nameof( _cursor ) ),

			Radius.Small => ElementClass.Empty()
				.Add( "rounded-medium", when: slot is nameof( _tabList ) )
				.Add( "rounded-small", when: slot is nameof( _tab ) )
				.Add( "rounded-small", when: slot is nameof( _cursor ) ),

			Radius.Medium => ElementClass.Empty()
				.Add( "rounded-medium", when: slot is nameof( _tabList ) )
				.Add( "rounded-small", when: slot is nameof( _tab ) )
				.Add( "rounded-small", when: slot is nameof( _cursor ) ),

			Radius.Large => ElementClass.Empty()
				.Add( "rounded-large", when: slot is nameof( _tabList ) )
				.Add( "rounded-medium", when: slot is nameof( _tab ) )
				.Add( "rounded-medium", when: slot is nameof( _cursor ) ),

			Radius.Full => ElementClass.Empty()
				.Add( "rounded-full", when: slot is nameof( _tabList ) )
				.Add( "rounded-full", when: slot is nameof( _tab ) )
				.Add( "rounded-full", when: slot is nameof( _cursor ) ),

			_ => ElementClass.Empty()
		};
	}

	private static ElementClass GetFullWidthStyles( bool isFullWidth, string slot )
	{
		return isFullWidth switch
		{
			true => ElementClass.Empty()
				.Add( "w-full", when: slot is nameof( _base ) )
				.Add( "w-full", when: slot is nameof( _tabList ) ),

			_ => ElementClass.Empty()
		};
	}

	private static ElementClass GetDisabledStyles( bool isDisabled, string slot )
	{
		return isDisabled switch
		{
			true => ElementClass.Empty()
				.Add( "opacity-disabled pointer-events-none", when: slot is nameof( _tabList ) ),

			_ => ElementClass.Empty()
		};
	}

	private static ElementClass GetCompoundStyles( TabVariant variant, ThemeColor color, string slot )
	{
		return (variant, color) switch
		{
			// solid / outlined / light && color

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Default ) => ElementClass.Empty()
				.Add( "bg-background dark:bg-default shadow-small", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-default-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Primary ) => ElementClass.Empty()
				.Add( ColorVariants.Solid[ThemeColor.Primary], when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-primary-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Secondary ) => ElementClass.Empty()
				.Add( ColorVariants.Solid[ThemeColor.Secondary], when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-secondary-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Success ) => ElementClass.Empty()
				.Add( ColorVariants.Solid[ThemeColor.Success], when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-success-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Warning ) => ElementClass.Empty()
				.Add( ColorVariants.Solid[ThemeColor.Warning], when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-warning-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Danger ) => ElementClass.Empty()
				.Add( ColorVariants.Solid[ThemeColor.Danger], when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-danger-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Solid or TabVariant.Outlined or TabVariant.Light, ThemeColor.Info ) => ElementClass.Empty()
				.Add( ColorVariants.Solid[ThemeColor.Info], when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-info-foreground", when: slot is nameof( _tabContent ) ),

			// underlined && color

			(TabVariant.Underlined, ThemeColor.Default ) => ElementClass.Empty()
				.Add( "bg-foreground", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-foreground", when: slot is nameof( _tabContent ) ),

			(TabVariant.Underlined, ThemeColor.Primary ) => ElementClass.Empty()
				.Add( "bg-primary", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-primary", when: slot is nameof( _tabContent ) ),

			(TabVariant.Underlined, ThemeColor.Secondary ) => ElementClass.Empty()
				.Add( "bg-secondary", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-secondary", when: slot is nameof( _tabContent ) ),

			(TabVariant.Underlined, ThemeColor.Success ) => ElementClass.Empty()
				.Add( "bg-success", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-success", when: slot is nameof( _tabContent ) ),

			(TabVariant.Underlined, ThemeColor.Warning ) => ElementClass.Empty()
				.Add( "bg-warning", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-warning", when: slot is nameof( _tabContent ) ),

			(TabVariant.Underlined, ThemeColor.Danger ) => ElementClass.Empty()
				.Add( "bg-danger", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-danger", when: slot is nameof( _tabContent ) ),

			(TabVariant.Underlined, ThemeColor.Info ) => ElementClass.Empty()
				.Add( "bg-info", when: slot is nameof( _cursor ) )
				.Add( "group-data-[selected=true]:text-info", when: slot is nameof( _tabContent ) ),

			_ => ElementClass.Empty()
		};
	}
}