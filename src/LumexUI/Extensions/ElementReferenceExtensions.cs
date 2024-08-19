// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Extensions;

[ExcludeFromCodeCoverage]
public static class ElementReferenceExtensions
{
    [UnsafeAccessor( UnsafeAccessorKind.Field, Name = "<JSRuntime>k__BackingField" )]
    private static extern ref IJSRuntime GetJSRuntime( WebElementReferenceContext context );

    public static ValueTask<int> GetScrollHeightAsync( this ElementReference? elementReference )
    {
        var jsRuntime = elementReference.GetJSRuntime();
        return jsRuntime.InvokeAsync<int>( "Lumex.elementReference.getScrollHeight", elementReference );
    }

    public static ValueTask PortalToAsync( this ElementReference? elementReference )
    {
        return PortalToAsync( elementReference, "body" );
    }

    public static ValueTask PortalToAsync( this ElementReference? elementReference, string selector )
    {
        var jsRuntime = elementReference.GetJSRuntime();
        return jsRuntime.InvokeVoidAsync( "Lumex.elementReference.portalTo", elementReference, selector );
    }

    private static IJSRuntime GetJSRuntime( this ElementReference? elementReference )
    {
        if( elementReference is not { Context: WebElementReferenceContext context } )
        {
            throw new InvalidOperationException( "ElementReference has not been configured correctly." );
        }

        return GetJSRuntime( context ) ?? throw new InvalidOperationException( "No JavaScript runtime found." );
    }
}
