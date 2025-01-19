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
		.Add( "outline-none" )
		.Add( "cursor-pointer" )
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

	private static readonly string _cursor = ElementClass.Empty()
		.Add( "z-0" )
		.Add( "absolute" )
		.Add( "bg-white" )
		.ToString();

	private static readonly string _tabPanel = ElementClass.Empty()
		.Add( "px-1" )
		.Add( "py-3" )
		.Add( "outline-none" )
		// focus ring
		.Add( Utils.FocusVisible )
		.ToString();

	public static TabsSlots GetStyles( LumexTabs tabs, TwMerge twMerge )
	{
		return new TabsSlots()
		{
			Root = twMerge.Merge(
				ElementClass.Empty()
					.Add( _base )
					.Add( tabs.Class )
					.ToString() ),

			TabList = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tabList )
					.Add( GetVariantStyles( tabs.Variant, slot: nameof( _tabList ) ) )
					.ToString() ),

			Tab = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tab )
					.ToString() ),

			TabContent = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tabContent )
					.ToString() ),

			Cursor = twMerge.Merge(
				ElementClass.Empty()
					.Add( _cursor )
					.ToString() ),

			TabPanel = twMerge.Merge(
				ElementClass.Empty()
					.Add( _tabPanel )
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
				.Add( "bg-transparent border-medium border-default-200 shadow-sm", when: slot is nameof( _tabList ) )
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
}
