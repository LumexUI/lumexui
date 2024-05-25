// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Extensions;

[ExcludeFromCodeCoverage]
public static class ElementReferenceExtensions
{
    private static readonly PropertyInfo? _jsRuntimeProp = typeof( WebElementReferenceContext )
        .GetProperty( "JSRuntime", BindingFlags.Instance | BindingFlags.NonPublic );

    public static ValueTask<int> GetScrollHeightAsync( this ElementReference elementReference )
    {
        var jsRuntime = elementReference.GetJSRuntime();
        return jsRuntime.InvokeAsync<int>( "Lumex.elementReference.getScrollHeight", elementReference );
    }

    private static IJSRuntime GetJSRuntime( this ElementReference elementReference )
    {
        if( elementReference.Context is not WebElementReferenceContext context )
        {
            throw new InvalidOperationException( "ElementReference has not been configured correctly." );
        }

        var jsRuntime = (IJSRuntime?)_jsRuntimeProp?.GetValue( context );
        return jsRuntime ?? throw new InvalidOperationException( "No JavaScript runtime found." );
    }
}
