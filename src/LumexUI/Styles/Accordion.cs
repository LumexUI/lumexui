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
            .Add( accordion.Classes?.Root )
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

    private readonly static string _content = ElementClass.Empty()
        .Add( "pb-3" )
        .ToString();

    public static string GetStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .Add( accordionItem.Class )
            .ToString();
    }

    public static string GetHeadingStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .ToString();
    }

    public static string GetTriggerStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .Add( _trigger )
            .ToString();
    }

    public static string GetTitleWrapperStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .Add( _titleWrapper )
            .ToString();
    }

    public static string GetTitleStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .Add( _title )
            .ToString();
    }

    public static string GetSubtitleStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .Add( _subtitle )
            .ToString();
    }

    public static string GetContentStyles( LumexAccordionItem accordionItem )
    {
        return ElementClass.Empty()
            .Add( _content )
            .ToString();
    }
}
