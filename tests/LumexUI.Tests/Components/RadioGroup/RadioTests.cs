// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Variants;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class RadioTests : TestContext
{
    public RadioTests()
    {
        Services.AddSingleton<TwMerge>();
		Services.AddSingleton<TwVariant>();
	}
    
    [Fact]
    public void Radio_MustBeInsideRadioGroup()
    {
        var action = () =>
            RenderComponent<LumexRadio<string>>( p =>
                p.Add( r => r.Value, "tallinn" )
                    .AddChildContent( "Tallinn" )
            );

        action.Should().ThrowExactly<ContextNullException>( "LumexRadio can only be used inside a LumexRadioGroup component" );
    }
}