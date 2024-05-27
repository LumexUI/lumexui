// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Accordion
{
    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    public static string GetStyles( LumexAccordion accordion )
    {
        return ElementClass.Empty()
            .Add( _fullWidth, when: accordion.FullWidth )
            .Add( accordion.Class )
            .ToString();
    }
}

[ExcludeFromCodeCoverage]
internal readonly record struct AccordionItem
{
    private readonly static string _trigger = ElementClass.Empty()
        .Add( "flex" )
        .Add( "py-4" )
        .Add( "w-full" )
        .Add( "items-center" )
        .Add( "outline-none" )
        .ToString();

    private readonly static string _startContent = ElementClass.Empty()
        .Add( "flex-shrink-0" )
        .ToString();

    private readonly static string _titleWrapper = ElementClass.Empty()
        .Add( "flex" )
        .Add( "flex-1" )
        .Add( "flex-col" )
        .Add( "text-start" )
        .ToString();

    private readonly static string _title = ElementClass.Empty()
        .Add( "text-foreground" )
        .Add( "text-large" )
        .ToString();

    private readonly static string _subtitle = ElementClass.Empty()
        .Add( "text-foreground-500" )
        .Add( "text-small" )
        .ToString();

    private readonly static string _indicator = ElementClass.Empty()
        .Add( "text-default-400" )
        .Add( "rotate-0" )
        .Add( "data-[open]:-rotate-90" )
        .Add( "transition-transform" )
        .ToString();

    private readonly static string _content = ElementClass.Empty()
        .Add( "py-2" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    public static string GetStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _disabled, when: accordionItem.GetDisabledState() )
            .Add( accordion.ItemClasses?.Root )
            .Add( accordionItem.Classes?.Root )
            .Add( accordionItem.Class )
            .ToString();
    }

    public static string GetHeadingStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( accordion.ItemClasses?.Heading )
            .Add( accordionItem.Classes?.Heading )
            .ToString();
    }

    public static string GetTriggerStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _trigger )
            .Add( accordion.ItemClasses?.Trigger )
            .Add( accordionItem.Classes?.Trigger )
            .ToString();
    }

    public static string GetStartContentStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _startContent )
            .Add( accordion.ItemClasses?.StartContent )
            .Add( accordionItem.Classes?.StartContent )
            .ToString();
    }

    public static string GetTitleWrapperStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _titleWrapper )
            .Add( accordion.ItemClasses?.TitleWrapper )
            .Add( accordionItem.Classes?.TitleWrapper )
            .ToString();
    }

    public static string GetTitleStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _title )
            .Add( accordion.ItemClasses?.Title )
            .Add( accordionItem.Classes?.Title )
            .ToString();
    }

    public static string GetSubtitleStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _subtitle )
            .Add( accordion.ItemClasses?.Subtitle )
            .Add( accordionItem.Classes?.Subtitle )
            .ToString();
    }

    public static string GetIndicatorStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _indicator )
            .Add( accordion.ItemClasses?.Indicator )
            .Add( accordionItem.Classes?.Indicator )
            .ToString();
    }

    public static string GetContentStyles( LumexAccordionItem accordionItem )
    {
        var accordion = accordionItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _content )
            .Add( accordion.ItemClasses?.Content )
            .Add( accordionItem.Classes?.Content )
            .ToString();
    }
}
