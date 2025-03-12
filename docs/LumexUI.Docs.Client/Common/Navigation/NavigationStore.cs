// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Docs.Client.Common;

public class NavigationStore
{
	private static Navigation? _navigation;

	private static NavigationCategory GettingStartedCategory =>
		new NavigationCategory( "Getting Started", Icons.Rounded.AutoStories )
			.Add( new( "Overview" ) )
			.Add( new( "Installation" ) );

	private static NavigationCategory CustomizationCategory =>
		new NavigationCategory( "Customization", Icons.Rounded.DesignServices )
			.Add( new( "Theme" ) )
			.Add( new( "Layout" ) )
			.Add( new( "Colors" ) )
			.Add( new( "Customize Theme" ) );

	private static NavigationCategory ComponentsCategory =>
		new NavigationCategory( "Components", Icons.Rounded.Joystick )
			.Add( new( nameof( LumexAccordion ) ) )
			.Add( new( nameof( LumexAvatar ), ComponentStatus.New ) )
			.Add( new( nameof( LumexButton ) ) )
			.Add( new( nameof( LumexCard ) ) )
			.Add( new( nameof( LumexCheckbox ) ) )
			.Add( new( nameof( LumexCheckboxGroup ) ) )
			.Add( new( nameof( LumexCollapse ) ) )
			.Add( new( nameof( LumexDataGrid<T> ) ) )
			.Add( new( nameof( LumexDivider ) ) )
			.Add( new( nameof( LumexDropdown ) ) )
			.Add( new( nameof( LumexIcon ) ) )
			.Add( new( nameof( LumexLink ) ) )
			.Add( new( nameof( LumexListbox<T> ) ) )
			.Add( new( nameof( LumexNavbar ) ) )
			.Add( new( nameof( LumexNumbox<T> ) ) )
			.Add( new( nameof( LumexPopover ) ) )
			.Add( new( nameof( LumexRadioGroup<T> ) ) )
			.Add( new( nameof( LumexSelect<T> ) ) )
			.Add( new( nameof( LumexSwitch ) ) )
			.Add( new( nameof( LumexTabs ) ) )
			.Add( new( nameof( LumexTextbox ) ) );

	private static NavigationCategory ComponentsApiCategory =>
		new NavigationCategory( "Components API", Icons.Rounded.Manufacturing )
			.Add( new( nameof( LumexAccordion ) ) )
			.Add( new( nameof( LumexAccordionItem ) ) )
			.Add( new( nameof( LumexAvatar ) ) )
			//.Add( nameof( LumexBooleanInputBase ) )
			.Add( new( nameof( LumexButton ) ) )
			.Add( new( nameof( LumexCard ) ) )
			.Add( new( nameof( LumexCardBody ) ) )
			.Add( new( nameof( LumexCardFooter ) ) )
			.Add( new( nameof( LumexCardHeader ) ) )
			.Add( new( nameof( LumexCheckbox ) ) )
			.Add( new( nameof( LumexCheckboxGroup ) ) )
			.Add( new( nameof( LumexCollapse ) ) )
			.Add( new( nameof( LumexComponent ) ) )
			//.Add( nameof( LumexComponentBase ) )
			//.Add( nameof( LumexDebouncedInputBase<T> ) )
			.Add( new( nameof( LumexDivider ) ) )
			.Add( new( nameof( LumexDropdown ) ) )
			.Add( new( nameof( LumexDropdownItem ) ) )
			.Add( new( nameof( LumexDropdownMenu ) ) )
			//.Add( nameof( LumexInputBase<T> ) )
			//.Add( nameof( LumexInputFieldBase<T> ) )
			.Add( new( nameof( LumexIcon ) ) )
			.Add( new( nameof( LumexLink ) ) )
			.Add( new( nameof( LumexListbox<T> ) ) )
			.Add( new( nameof( LumexListboxItem<T> ) ) )
			.Add( new( nameof( LumexNavbar ) ) )
			.Add( new( nameof( LumexNavbarBrand ) ) )
			.Add( new( nameof( LumexNavbarContent ) ) )
			.Add( new( nameof( LumexNavbarItem ) ) )
			.Add( new( nameof( LumexNavbarMenu ) ) )
			.Add( new( nameof( LumexNavbarMenuItem ) ) )
			.Add( new( nameof( LumexNavbarMenuToggle ) ) )
			.Add( new( nameof( LumexNumbox<T> ) ) )
			.Add( new( nameof( LumexPopover ) ) )
			.Add( new( nameof( LumexPopoverContent ) ) )
			.Add( new( nameof( LumexPopoverTrigger ) ) )
			.Add( new( nameof( LumexSelect<T> ) ) )
			.Add( new( nameof( LumexSelectItem<T> ) ) )
			.Add( new( nameof( LumexSwitch ) ) )
			.Add( new( nameof( LumexTab ) ) )
			.Add( new( nameof( LumexTabs ) ) )
			.Add( new( nameof( LumexTextbox ) ) )
			.Add( new( nameof( LumexThemeProvider ) ) );

	public static Navigation GetNavigation()
	{
		_navigation ??= new Navigation()
			.Add( GettingStartedCategory )
			.Add( CustomizationCategory )
			.Add( ComponentsCategory )
			.Add( ComponentsApiCategory );

		return _navigation;
	}
}
