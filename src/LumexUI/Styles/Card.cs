// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Card
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "relative" )
        .Add( "text-foreground" )
        .Add( "overflow-hidden" )
        .Add( "bg-surface1" )
        .ToString();

    private readonly static string _header = ElementClass.Empty()
        .Add( "z-10" )
        .Add( "flex" )
        .Add( "px-4" )
        .Add( "py-3" )
        .Add( "w-full" )
        .Add( "justify-start" )
        .Add( "items-center" )
        .Add( "overflow-hidden" )
        .ToString();

    private readonly static string _body = ElementClass.Empty()
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "relative" )
        .Add( "px-4" )
        .Add( "py-3" )
        .Add( "w-full" )
        .Add( "text-left" )
        .Add( "break-words" )
        .ToString();

    private readonly static string _footer = ElementClass.Empty()
        .Add( "flex" )
        .Add( "px-4" )
        .Add( "py-3" )
        .Add( "w-full" )
        .Add( "items-center" )
        .Add( "overflow-hidden" )
        .ToString();

    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    private readonly static string _blurred = ElementClass.Empty()
        .Add( "bg-background/80" )
        .Add( "dark:bg-background/20" )
        .Add( "backdrop-blur-md" )
        .Add( "backdrop-saturate-150" )
        .ToString();

    private readonly static string _blurredFooter = ElementClass.Empty()
        .Add( "bg-background/10" )
        .Add( "backdrop-blur-md" )
        .Add( "backdrop-saturate-150" )
        .ToString();

    private static ElementClass GetShadowStyles( Shadow shadow )
    {
        return ElementClass.Empty()
            .Add( "shadow-none", when: shadow is Shadow.None )
            .Add( "shadow-small", when: shadow is Shadow.Small )
            .Add( "shadow-medium", when: shadow is Shadow.Medium )
            .Add( "shadow-large", when: shadow is Shadow.Large );
    }

    private static ElementClass GetRadiusStyles( Radius radius, string slot )
    {
        if( slot == "root" )
        {
            return ElementClass.Empty()
                .Add( "rounded-none", when: radius is Radius.None )
                .Add( "rounded-small", when: radius is Radius.Small )
                .Add( "rounded-medium", when: radius is Radius.Medium )
                .Add( "rounded-large", when: radius is Radius.Large );
        }
        else if( slot == "header" )
        {
            return ElementClass.Empty()
                .Add( "rounded-none", when: radius is Radius.None )
                .Add( "rounded-t-small", when: radius is Radius.Small )
                .Add( "rounded-t-medium", when: radius is Radius.Medium )
                .Add( "rounded-t-large", when: radius is Radius.Large );
        }
        else // part == "footer"
        {
            return ElementClass.Empty()
                .Add( "rounded-none", when: radius is Radius.None )
                .Add( "rounded-b-small", when: radius is Radius.Small )
                .Add( "rounded-b-medium", when: radius is Radius.Medium )
                .Add( "rounded-b-large", when: radius is Radius.Large );
        }
    }

    public static string GetStyles( LumexCard card )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _blurred, when: card.Blurred )
            .Add( _fullWidth, when: card.FullWidth )
            .Add( GetShadowStyles( card.Shadow ) )
            .Add( GetRadiusStyles( card.Radius, slot: "root" ) )
            .Add( card.Classes?.Base )
            .Add( card.Class )
            .ToString();
    }

    public static string GetHeaderStyles( LumexCardHeader cardHeader )
    {
        var card = cardHeader.Context.Owner;

        return ElementClass.Empty()
            .Add( _header )
            .Add( GetRadiusStyles( card.Radius, slot: "header" ) )
            .Add( card.Classes?.Header )
            .Add( cardHeader.Class )
            .ToString();
    }

    public static string GetBodyStyles( LumexCardBody cardBody )
    {
        var card = cardBody.Context.Owner;

        return ElementClass.Empty()
            .Add( _body )
            .Add( card.Classes?.Body )
            .Add( cardBody.Class )
            .ToString();
    }

    public static string GetFooterStyles( LumexCardFooter cardFooter )
    {
        var card = cardFooter.Context.Owner;

        return ElementClass.Empty()
            .Add( _footer )
            .Add( _blurredFooter, when: cardFooter.Blurred )
            .Add( GetRadiusStyles( card.Radius, slot: "footer" ) )
            .Add( card.Classes?.Footer )
            .Add( cardFooter.Class )
            .ToString();
    }
}
